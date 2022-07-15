using UnityEngineAssets.Scripts.Spawners;
using UnityEditor;
using UnityEngine;

namespace UnityEngineAssets.Editor
{
    [CustomEditor(typeof(RandomRainSpawner))]
    public class RandomRainSpawnerEditor : UnityEditor.Editor
    {
        static bool m_drawHandles;
        static bool m_drawGizmos;

        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField(
                    "Spawns random primitives or an assigned prefab between corners that move along the y-axis.",
                    EditorStyles.helpBox
                );

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Gizmos and Handles", EditorStyles.boldLabel);
            m_drawGizmos = EditorGUILayout.Toggle("Draw Gizmos", m_drawGizmos);
            m_drawHandles = EditorGUILayout.Toggle("Draw Handles", m_drawHandles);
            if (Application.isPlaying && GUILayout.Button("Clear Pool and GameObjects")) (target as RandomRainSpawner).ClearPoolAndGameObjects();
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
        private static void DrawGizmos(RandomRainSpawner spawner, GizmoType gizmoType)
        {
            if (!m_drawGizmos) return;

            EditorHelpers.Gizmos.DrawWireCornerCube(spawner.Corner0, spawner.Corner1, Color.yellow);
        }

        private void OnSceneGUI()
        {
            if (!m_drawHandles) return;

            RandomRainSpawner spawner = (RandomRainSpawner)target;

            EditorGUI.BeginChangeCheck();
            Vector3 top = Handles.PositionHandle(spawner.Corner1, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(spawner, "Modified TopCorner");
                spawner.Corner1 = top;
            }

            EditorGUI.BeginChangeCheck();
            Vector3 bottom = Handles.PositionHandle(spawner.Corner0, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(spawner, "Modified BottomCorner");
                spawner.Corner0 = bottom;
            }
        }
    }
}