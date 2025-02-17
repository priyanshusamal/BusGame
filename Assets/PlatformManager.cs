using UnityEngine;

public class PlatformManager : MonoBehaviour { 
    public GameObject platformPrefab; 
    private GameObject selectedPlatform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Platform"))
                {
                    selectedPlatform = hit.collider.gameObject;
                }
            }
        }
        else if (Input.GetMouseButton(0) && selectedPlatform != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPlatform.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedPlatform = null;
        }
    }

}
