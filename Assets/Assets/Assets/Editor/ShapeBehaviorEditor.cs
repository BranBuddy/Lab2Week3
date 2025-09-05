using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ShapeBehavior)), CanEditMultipleObjects]  
public class ShapeBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var shapeSize = GameObject.FindAnyObjectByType<ShapeBehavior>();
        if (shapeSize.shapeSize < 0)
        {
            EditorGUILayout.HelpBox("Size of Shape cannot be less than 0!", MessageType.Warning);
        }


        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Select All Cubes"))
        {

            var allShapeBehavior = GameObject.FindGameObjectsWithTag("Cube");
            var allShapeGO = allShapeBehavior.Select(shapes => shapes.gameObject).ToArray();
            Selection.objects = allShapeGO;
        }

        if (GUILayout.Button("Select All Spheres"))
        {

            var allShapeBehavior = GameObject.FindGameObjectsWithTag("Sphere");
            var allShapeGO = allShapeBehavior.Select(shapes => shapes.gameObject).ToArray();
            Selection.objects = allShapeGO;
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = new Object[]
            {
                (target as ShapeBehavior).gameObject
            };

        }

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;

        if (GUILayout.Button("Disable/Enable All Shapes", GUILayout.Height(40)))
        {
            bool isTurnedOn = true;
            if (isTurnedOn)
            {
                foreach (var shape in GameObject.FindGameObjectsWithTag("Handler"))
                {
                    Undo.RecordObject(shape.gameObject, "Disable/Enable All Shapes");
                    shape.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    shape.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    
                }

                isTurnedOn = true;
            }
            else
            {
                foreach (var shape in GameObject.FindGameObjectsWithTag("Handler"))
                {
                    Undo.RecordObject(shape.gameObject, "Disable/Enable All Shapes");
                    shape.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    shape.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    
                }

                isTurnedOn = true;
            }
            
        }

            GUI.backgroundColor = cachedColor;

        }

}
