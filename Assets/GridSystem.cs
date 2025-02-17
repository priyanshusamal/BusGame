using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
public class GridSystem : MonoBehaviour
{
    public Transform tileParent;
    public GameObject tilePrefab; // Assign a 3D tile prefab in Unity Inspector
    public GameObject borderPrefab; // Assign a border prefab
    public int gridSizeX = 10, gridSizeY = 10;
    public float tileSize = 1.0f;

    private Dictionary<Vector2Int, GameObject> tiles = new Dictionary<Vector2Int, GameObject>();

    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        HandleEditorInput();
        pointer.transform.localScale = new Vector3(tileSize,tileSize,tileSize);
        pointer.transform.position = GetPointerPosition();
    }

    // public void Update()
    // {

    // }
    public GameObject pointer;
    void OnDrawGizmos()
    {
    }
    public Vector3 GetPointerPosition(){
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);
            return new Vector3(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y),0);
        }
        return Vector3.zero;
        // return new Vector3(0,0,0);
    }
    public void HandleEditorInput()
    {
        Event e = Event.current;
        if (e == null) return;

        if ((e.type == EventType.MouseDown || e.type == EventType.MouseDrag) && e.button == 0) // Left Click - Place Tile
        {
            Vector2Int gridPos = GetGridPositionFromMouse();
            if (!tiles.ContainsKey(gridPos))
            {
            // Debug.Log(gridPos);
                PlaceTile(gridPos);
                e.Use();
            }
        }
        else if ((e.type == EventType.MouseDown || e.type == EventType.MouseDrag) && e.button == 1) // Right Click - Remove Tile
        {
            Vector2Int gridPos = GetGridPositionFromMouse();
            if (tiles.ContainsKey(gridPos))
            {
                RemoveTile(gridPos);
                e.Use();
            }
        }
    }
    
    public Vector2Int GetGridPositionFromMouse()
    {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);
            return new Vector2Int(Mathf.FloorToInt(worldPosition.x / tileSize), Mathf.FloorToInt(worldPosition.y / tileSize));
        }
        return Vector2Int.zero;
    }

    public void PlaceTile(Vector2Int position)
    {
        if(!tiles.ContainsKey(position))
        {
            GameObject newTile = Instantiate(tilePrefab, new Vector3(position.x * tileSize, position.y * tileSize,0), Quaternion.identity,tileParent);
            newTile.transform.localScale = Vector3.one * tileSize;
            tiles.Add(position, newTile);
        }
        // UpdateBorders(position);
    }

    public void RemoveTile(Vector2Int position)
    {
        if (tiles.ContainsKey(position))
        {
            DestroyImmediate(tiles[position]);
            tiles.Remove(position);
            // UpdateBorders(position);
        }
    }

    public void UpdateBorders(Vector2Int position)
    {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        
        foreach (var dir in directions)
        {
            Vector2Int neighborPos = position + dir;
            bool hasNeighbor = tiles.ContainsKey(neighborPos);

            if (hasNeighbor)
            {
                RemoveBorder(neighborPos, -dir);
            }
            else
            {
                PlaceBorder(position, dir);
            }
        }
    }

    public void PlaceBorder(Vector2Int position, Vector2Int direction)
    {
        Vector3 borderPosition = new Vector3(position.x * tileSize + direction.x * tileSize / 2, position.y * tileSize + direction.y * tileSize / 2,0);
        GameObject border = Instantiate(borderPrefab, borderPosition, Quaternion.identity);
        border.transform.parent = tiles[position].transform; // Attach border to tile
    }

    public void RemoveBorder(Vector2Int position, Vector2Int direction)
    {
        foreach (Transform child in tiles[position].transform)
        {
            if (child.CompareTag("Border"))
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}
