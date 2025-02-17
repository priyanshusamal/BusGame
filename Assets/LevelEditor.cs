
using UnityEditor; 
using UnityEngine;

[CustomEditor(typeof(GridManager))] 
public class LevelEditor : Editor 
{ 
    public override void OnInspectorGUI() 
    { 
        DrawDefaultInspector();
        GridManager gridManager = (GridManager)target;
        if (GUILayout.Button("Add Row"))
        {
            gridManager.AddRow();
        }
        if (GUILayout.Button("Add Column"))
        {
            gridManager.AddColumn();
        }
    }
}