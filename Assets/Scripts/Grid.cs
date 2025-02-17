using UnityEngine;
using BusGame.Scripts;
public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    public Grid(int width, int height, float cellSize ,Transform parent, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition =originPosition;
        gridArray = new int[width,height];

        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                Utilities.CreateWorldObject(new Vector2Int(x,y), parent, GetWorldPosition(x,y)+ new Vector3(cellSize,cellSize,0)*0.5f,cellSize);
                Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x,y+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x+1,y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height),GetWorldPosition(width,height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,height),GetWorldPosition(width,0), Color.white, 100f);
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y)*cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition-originPosition).x/cellSize);
        y = Mathf.FloorToInt((worldPosition-originPosition).y/cellSize);
    }
    public void  SetValue(int x, int y , GameObject obj)
    {
        if(x>=0 || y>=0 && x < width && y < height)
        {
            // gridArray[x,y]
            Debug.Log(x+" , "+y);

        }
    }
    public void SetValue(Vector3 worldPosition, GameObject obj)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        SetValue(x, y, obj);
    }

    public int GetValue(int x, int y)
    {
        if(x >= 0 && y >=0 && x < width && y < height)
        {
            return gridArray[x,y];
        }
        else{return 0;}
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x,y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x,y);
    }
}


