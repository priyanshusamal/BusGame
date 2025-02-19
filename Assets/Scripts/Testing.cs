using UnityEngine;
using BusGame.Scripts;
using UnityEngine.Tilemaps;

namespace BusGame.Scripts{
    public class Testing : MonoBehaviour
    {
        Tilemap tilemap;
        void Start()
        {
        tilemap = new Tilemap(8,12,1,new Vector3(4,-4,0));
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                // tilemap.SetValue(Utilities.GetMouseWorldPosition(), brush[brushIndex]);
                tilemap.SetTilemapSprite(Utilities.GetMouseWorldPosition(),Tilemap.TilemapObject.TilemapSprite.Ground);
            }

            
        }
        
        // public class HeatMap
    }
}
// using UnityEngine;
// using BusGame.Scripts;
// public class Testing : MonoBehaviour
// {
//     private Grid<TileMap> grid;
//     [SerializeField]private GameObject[] brush;
//     public int brushIndex = 0;
//     void Start()
//     {
       
//     }

//     private void Update()
//     {
//         if(Input.GetMouseButtonDown(0))
//         {
//             grid.SetValue(Utilities.GetMouseWorldPosition(), brush[brushIndex]);
//         }
//         if(Input.GetMouseButtonDown(1))
//         {
//             grid.GetGridObject(Utilities.GetMouseWorldPosition());
//         }
        
//     }
    
//     // public class HeatMap
// }