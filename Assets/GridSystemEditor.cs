using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridSystem))]
public class GridSystemEditor : Editor
{
    private void OnSceneGUI()
    {
        GridSystem grid = (GridSystem)target;
        Event e = Event.current;

        if (e.type == EventType.MouseDown && (e.button == 0 || e.button == 1))
        {
            Vector2Int gridPos = grid.GetGridPositionFromMouse();
            if (e.button == 0) grid.PlaceTile(gridPos);
            else if (e.button == 1) grid.RemoveTile(gridPos);
            
            e.Use();
        }
    }
}