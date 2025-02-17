using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int GridPosition { get; private set; }

    public void SetPosition(Vector2Int position)
    {
        GridPosition = position;
    }
}

