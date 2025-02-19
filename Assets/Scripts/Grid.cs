using UnityEngine;
using BusGame.Scripts;
using System;
public class Grid<TGridObject>
{
    public const int HEAT_MAP_MAX_VALUE = 100;
    public const int HEAT_MAP_MIN_VALUE = 0;
    public event EventHandler<OnGridObjectChangedEventArgs> onGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    public Grid(int width, int height, float cellSize ,Transform parent, Vector3 originPosition, Func<Grid<TGridObject>,int,int,TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition =originPosition;
        gridArray = new TGridObject[width,height];

        
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                // gridArray[x,y] = createGridObject();
            }
        }
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
    public void  SetValue(int x, int y , TGridObject value)
    {
        if(x>=0 || y>=0 && x < width && y < height)
        {
            // gridArray[x,y] = Mathf.Clamp(value, HEAT_MAP_MIN_VALUE,HEAT_MAP_MAX_VALUE);
            // Debug.Log(x+" , "+y);
            // Utilities.CreateTile(obj,null,new Vector3(x,y,0),0.5f);

        }
    }
    public void TriggerGridObjectChanged(int x, int y)
    {
        if(onGridObjectChanged != null) onGridObjectChanged(this, new OnGridObjectChangedEventArgs{x = x, y = y});
    }
    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        SetValue(x, y, value);
    }

            // Debug.Log(gridArray[x,y]);
    public TGridObject GetGridObject(int x, int y)
    {
        if(x >= 0 && y >=0 && x < width && y < height)
        {
            Debug.Log(gridArray[x,y]);
            return gridArray[x,y];
        }
        else{return default(TGridObject);}
    }
    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x,y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x,y);
    }
}


