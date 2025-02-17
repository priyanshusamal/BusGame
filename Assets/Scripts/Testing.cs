using UnityEngine;
using BusGame.Scripts;
public class Testing : MonoBehaviour
{
    private Grid grid;
    [SerializeField]private GameObject[] brush;
    public int brushIndex = 0;
    void Start()
    {
        grid = new Grid(7,10,0.5f,transform,new Vector3(-2f,-2f,0f));        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Utilities.GetMouseWorldPosition(), brush[brushIndex]);
        }
    }

}
