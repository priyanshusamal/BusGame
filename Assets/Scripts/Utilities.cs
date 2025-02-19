using UnityEngine;

namespace BusGame.Scripts
{
    public class Utilities{
        public static GameObject CreateWorldObject( Vector2Int nameID, Transform parent = null, Vector3 localPosition = default(Vector3),float localSize =1f)
        {
            GameObject cube = new GameObject("TileHolder", typeof(GameObject));
            // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = nameID.x+" x "+nameID.y;
            // cube.transform.position = new Vector3(0, 0.5f, 0);
            Transform transform = cube.transform;
            transform.SetParent(parent,false);
            transform.localPosition = localPosition;
            transform.localScale = new Vector3(localSize,localSize,localSize);
            return cube;
        }
        public static GameObject CreateTile(GameObject obj, Transform parent = null , Vector3 localPosition = default(Vector3),float localSize = 1f)
        {
            GameObject go = GameObject.Instantiate(obj,localPosition,obj.transform.rotation,parent);
            Transform transform = go.transform;
            transform.SetParent(parent);
            transform.localPosition = localPosition;
            transform.localScale = new Vector3(localSize,localSize,localSize);
            return go; 
        }
        // public static int DeleteTile(Transform parent , )
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }
    }

}