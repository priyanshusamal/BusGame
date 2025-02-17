using UnityEngine;

public class Border : MonoBehaviour
{
    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}