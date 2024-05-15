using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wheel))]
public class WheelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Wheel wheel = (Wheel)target;

        // Sabit boyut ayar�
        int fixedSize = 8; // �rne�in, 10 eleman s�n�r�

        if (wheel.rewards == null || wheel.rewards.Count != fixedSize)
        {
            wheel.rewards = new System.Collections.Generic.List<Reward>(fixedSize);
            for (int i = 0; i < fixedSize; i++)
            {
                wheel.rewards.Add(null);
            }
        }

        // Reward listesini g�ster
        for (int i = 0; i < fixedSize; i++)
        {
            wheel.rewards[i] = (Reward)EditorGUILayout.ObjectField($"Reward {i + 1}", wheel.rewards[i], typeof(Reward), false);
        }

        // Scene'deki de�i�iklikleri kaydet
        if (GUI.changed)
        {
            EditorUtility.SetDirty(wheel);
        }
    }
}
