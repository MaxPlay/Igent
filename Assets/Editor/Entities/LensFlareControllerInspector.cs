using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LensFlareController))]
[CanEditMultipleObjects]
public class LensFlareControllerInspector : Editor
{

    SerializedProperty Infinite;
    SerializedProperty Distance;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Infinite.boolValue = EditorGUILayout.Toggle("Is Infinite", Infinite.boolValue);
        if (!Infinite.boolValue)
        {
            Distance.floatValue = EditorGUILayout.FloatField("Distance", Distance.floatValue);
        }
        serializedObject.ApplyModifiedProperties();
    }

    void OnEnable()
    {
        Infinite = serializedObject.FindProperty("Infinite");
        Distance = serializedObject.FindProperty("Distance");
    }
}
