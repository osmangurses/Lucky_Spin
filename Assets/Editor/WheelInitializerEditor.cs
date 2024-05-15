using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WheelInitializer))]
public class WheelInitializerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Mevcut inspector'ý çiz

        WheelInitializer script = (WheelInitializer)target; // Hedef scripte eriþim

        if (GUILayout.Button("Pre Initialize")) // Buton çizimi
        {
            script.InitializeWheel(); // Butona týklandýðýnda InitializeWheel metodunu çalýþtýr
        }
    }
}
