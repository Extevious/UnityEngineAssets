using UnityEngineAssets.Scripts.Components;
using UnityEditor;

namespace UnityEngineAssets.Editor
{
    [CustomEditor(typeof(AutoDetacher))]
    public class AutoDetacherEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField(
                "Auto-detaches or sets parent on Unity event.",
                EditorStyles.helpBox
            );

            EditorGUILayout.Space();

            base.OnInspectorGUI();
        }
    }
}