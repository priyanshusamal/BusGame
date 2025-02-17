using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int gridPosition;
    public void SetPosition(Vector2Int position)
    {
        gridPosition = position;
    }
}