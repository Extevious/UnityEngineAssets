using UnityEngine;
using UnityEditor;
using UnityEngineAssets.Scripts.Tools;
using static UnityEngineAssets.Editor.EditorHelpers.GUI;
using static UnityEngineAssets.Editor.EditorHelpers.Gizmos;
using static UnityEngineAssets.Editor.EditorHelpers.Handles;
using System.Collections.Generic;
using System;

namespace UnityEngineAssets.Editor
{
    [CustomEditor(typeof(Telepoints))]
    public class TelepointsEditor : UnityEditor.Editor
    {
        private static Queue<Vector3> m_previousPointsQueue;
        private static bool m_drawHandles;
        private static bool m_drawGizmos;
        private static int m_trailCount = 10;
        private static bool m_drawTrail;
        Telepoints m_telepoints;

        private void OnEnable()
        {
            m_previousPointsQueue = new Queue<Vector3>();
            m_telepoints = (Telepoints)target;
            m_telepoints.onTeleportEvent += OnTeleport;
        }

        private void OnDisable()
        {
            m_telepoints.onTeleportEvent -= OnTeleport;
        }

        private void OnTeleport(Vector3 position)
        {
            if (m_previousPointsQueue.Count >= m_trailCount) m_previousPointsQueue.Dequeue();
            m_previousPointsQueue.Enqueue(position);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(
                "Teleports a GameObject randomly inside a cubical volume every x intervals.",
                EditorStyles.helpBox
            );

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            QuickBoldLabel("Gizmos and Handles");
            QuickToggleField(ref m_drawGizmos, "Draw Gizmos");
            QuickToggleField(ref m_drawHandles, "Draw Handles");

            GUILayout.BeginHorizontal();

            m_drawTrail = EditorGUILayout.BeginToggleGroup("Draw Trail", m_drawTrail);
            m_trailCount = EditorGUILayout.IntField(Math.Clamp(m_trailCount, 0, int.MaxValue));
            EditorGUILayout.EndToggleGroup();

            GUILayout.EndHorizontal();
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
        private static void DrawGizmos(Telepoints telepoints, GizmoType gizmoType)
        {
            if (!m_drawGizmos) return;

            DrawWireCornerCube(telepoints.Corner0, telepoints.Corner1, Color.yellow);

            if (m_drawTrail && m_previousPointsQueue.Count > 1)
            {
                Vector3 previousPoint = m_previousPointsQueue.Peek();

                Gizmos.color = Color.red;
                foreach (var point in m_previousPointsQueue)
                {
                    Gizmos.DrawLine(previousPoint, point);
                    previousPoint = point;
                }
            }
        }

        private void OnSceneGUI()
        {
            if (!m_drawHandles) return;

            if (PositionHandle(m_telepoints, m_telepoints.Corner0, "Corner0", out Vector3 newHandlePosition0)) m_telepoints.Corner0 = newHandlePosition0;
            if (PositionHandle(m_telepoints, m_telepoints.Corner1, "Corner0", out Vector3 newHandlePosition1)) m_telepoints.Corner1 = newHandlePosition1;
        }
    }
}
