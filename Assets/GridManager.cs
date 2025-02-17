using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int initialRows = 5;
    public int initialColumns = 5;
    public GameObject gridCellPrefab;
    public Transform gridParent;
    private Dictionary<Vector2Int, GridCell> gridCells = new Dictionary<Vector2Int, GridCell>();

    void Start()
    {
        GenerateGrid(initialRows, initialColumns);
    }

    void GenerateGrid(int rows, int columns)
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                CreateCell(new Vector2Int(x, y));
            }
        }
    }

    void CreateCell(Vector2Int position)
    {
        if (gridCells.ContainsKey(position)) return;
        GameObject cellObj = Instantiate(gridCellPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity, gridParent);
        GridCell cell = cellObj.GetComponent<GridCell>();
        cell.SetPosition(position);
        gridCells[position] = cell;
    }

    public void AddRow()
    {
        int maxY = 0;
        foreach (var key in gridCells.Keys)
        {
            if (key.y > maxY) maxY = key.y;
        }
        for (int x = 0; x < initialColumns; x++)
        {
            CreateCell(new Vector2Int(x, maxY + 1));
        }
    }

    public void AddColumn()
    {
        int maxX = 0;
        foreach (var key in gridCells.Keys)
        {
            if (key.x > maxX) maxX = key.x;
        }
        for (int y = 0; y < initialRows; y++)
        {
            CreateCell(new Vector2Int(maxX + 1, y));
        }
    }
}


