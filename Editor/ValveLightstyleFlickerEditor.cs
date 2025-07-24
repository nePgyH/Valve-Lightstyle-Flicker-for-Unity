using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ValveLightstyleFlicker))]
public class ValveLightstyleFlickerEditor : Editor
{
    SerializedProperty usePresetProp;
    SerializedProperty presetIDProp;
    SerializedProperty customPatternProp;
    SerializedProperty maxIntensityProp;
    SerializedProperty updatesPerSecondProp;

    private void OnEnable()
    {
        usePresetProp = serializedObject.FindProperty("_usePreset");
        presetIDProp = serializedObject.FindProperty("_presetID");
        customPatternProp = serializedObject.FindProperty("_customPattern");
        maxIntensityProp = serializedObject.FindProperty("_maxIntensity");
        updatesPerSecondProp = serializedObject.FindProperty("_updatesPerSecond");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(usePresetProp, new GUIContent("Use Preset"));

        if (usePresetProp.boolValue)
        {
            var presets = ValveLightstylePresets.All;
            int currentIndex = presets.FindIndex(p => p.ID == presetIDProp.stringValue);
            if (currentIndex == -1) currentIndex = 0;

            string[] presetNames = presets.ConvertAll(p => p.Name).ToArray();

            int newIndex = EditorGUILayout.Popup("Lightstyle Preset", currentIndex, presetNames);
            if (newIndex != currentIndex)
            {
                presetIDProp.stringValue = presets[newIndex].ID;
            }
        }
        else
        {
            EditorGUILayout.PropertyField(customPatternProp, new GUIContent("Custom Pattern"));
        }

        EditorGUILayout.PropertyField(maxIntensityProp);
        EditorGUILayout.PropertyField(updatesPerSecondProp);

        serializedObject.ApplyModifiedProperties();
    }
}
