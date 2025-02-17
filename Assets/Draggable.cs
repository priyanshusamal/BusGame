using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera cam;
    private Vector3 startPosition;
    private Transform startParent;

    public void Start()
    {
        cam = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        Debug.Log("dragBegin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 realPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(realPos.x,realPos.y,transform.position.z);
        Debug.Log("drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}