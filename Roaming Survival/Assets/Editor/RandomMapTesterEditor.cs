using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RandomMapTester))]
public class NewBehaviourScript : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var script = (RandomMapTester)target;

        if (GUILayout.Button("Generate Map"))
        {
            if (Application.isPlaying)
            {
                script.MakeMap();
            }

        }
    }
}
