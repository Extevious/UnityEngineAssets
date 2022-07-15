using UnityEngineAssets.Scripts.Components;
using UnityEditor;

namespace UnityEngineAssets.Editor
{
    [CustomEditor(typeof(TransformInterpolation))]
    public class TransformInterpolationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField(
                "Interpolates a Transform smoothly between 2 points during Update.",
                EditorStyles.helpBox
            );

            EditorGUILayout.Space();

            base.OnInspectorGUI();
        }
    }
}