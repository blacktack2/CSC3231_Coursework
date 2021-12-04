using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PositionOnTerrain))]
public class PositionOnTerrainEditor : Editor
{
    private PositionOnTerrain positioner;

    void OnEnable()
    {
        positioner = target as PositionOnTerrain;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Reposition", EditorStyles.miniButton))
            EditorApplication.delayCall += positioner.Reposition;
    }
}
