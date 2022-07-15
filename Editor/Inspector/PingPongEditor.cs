using UnityEngineAssets.Scripts.Tools;
using UnityEditor;
using UnityEngine;

namespace UnityEngineAssets.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PingPong))]
    public class PingPongEditor : UnityEditor.Editor
    {
        static bool m_drawHandles;
        static bool m_drawGizmos;

        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField(
                "Moves a Transform between two points. Ping pong ping pong..!",
                EditorStyles.helpBox
            );

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Gizmos and Handles", EditorStyles.boldLabel);
            m_drawGizmos = EditorGUILayout.Toggle("Draw Gizmos", m_drawGizmos);
            m_drawHandles = EditorGUILayout.Toggle("Draw Handles", m_drawHandles);
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
        private static void DrawGizmos(PingPong scr, GizmoType gizmoType)
        {
            if (!Application.isPlaying)
            {
                UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
                UnityEditor.SceneView.RepaintAll();
            }

            if (m_drawGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(scr.PositionA, 0.3f);
                Gizmos.DrawWireSphere(scr.PositionB, 0.3f);

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(scr.PositionA, scr.PositionB);
            }
        }

        private void OnSceneGUI()
        {
            if (!m_drawHandles) return;

            PingPong pingPong = (PingPong)target;

            EditorGUI.BeginChangeCheck();
            Vector3 a = Handles.PositionHandle(pingPong.PositionA, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(pingPong, "Modified PingPong PositionA");
                pingPong.PositionA = a;
                pingPong.EditorUpdate();
            }

            EditorGUI.BeginChangeCheck();
            Vector3 b = Handles.PositionHandle(pingPong.PositionB, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(pingPong, "Modified PingPong PositionB");
                pingPong.PositionB = b;
                pingPong.EditorUpdate();
            }
        }
    }
}
