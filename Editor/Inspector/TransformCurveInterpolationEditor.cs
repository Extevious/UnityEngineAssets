using UnityEngineAssets.Scripts.Components;
using UnityEditor;

namespace UnityEngineAssets.Editor
{
    [CustomEditor(typeof(TransformCurveInterpolation))]
    public class TransformCurveInterpolationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField(
                "Interpolates a Transform smoothly between 3 points on a curve during Update. The Transform will pass through all 3 points.",
                EditorStyles.helpBox
            );

            EditorGUILayout.Space();

            base.OnInspectorGUI();
        }
    }
}