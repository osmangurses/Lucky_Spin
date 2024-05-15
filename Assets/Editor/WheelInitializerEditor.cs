using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WheelInitializer))]
public class WheelInitializerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Mevcut inspector'� �iz

        WheelInitializer script = (WheelInitializer)target; // Hedef scripte eri�im

        if (GUILayout.Button("Pre Initialize")) // Buton �izimi
        {
            script.InitializeWheel(); // Butona t�kland���nda InitializeWheel metodunu �al��t�r
        }
    }
}
