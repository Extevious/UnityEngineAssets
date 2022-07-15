using UnityEngineAssets.Scripts.Tools;
using UnityEditor;
using UnityEngine;
using static UnityEngineAssets.Editor.EditorHelpers.GUI;

[CustomEditor(typeof(TransformTrail))]
public class TransformTrailEditor : UnityEditor.Editor
{
    private static bool m_drawRotation;
    private static bool m_drawVelocity;
    private static bool m_drawGizmos;
    private static bool m_drawTrail;

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField(
              "Renders trailing lines following this GameObject.",
              EditorStyles.helpBox
          );

        EditorGUILayout.Space();

        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();

        m_drawGizmos = EditorGUILayout.BeginToggleGroup("Draw Gizmos", m_drawGizmos);
        QuickToggleField(ref m_drawTrail, "Draw Trail");
        QuickToggleField(ref m_drawRotation, "Draw Rotation");
        QuickToggleField(ref m_drawVelocity, "Draw Velocity");
        EditorGUILayout.EndToggleGroup();

        GUILayout.EndHorizontal();
    }

    [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
    private static void DrawGizmos(TransformTrail transformTrail, GizmoType gizmoType)
    {
        if (!m_drawGizmos || !Application.isPlaying) return;

        if (transformTrail.TrailQueue.Count > 1)
        {
            TransformTrailPair previousPair = transformTrail.TrailQueue.Peek();

            foreach (var pair in transformTrail.TrailQueue)
            {
                if (m_drawTrail)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(previousPair.position, pair.position);
                }

                if (m_drawRotation)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(pair.position, pair.position + pair.up);
                }

                if (m_drawVelocity)
                {
                    Vector3 velocity = pair.position - previousPair.position;
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(pair.position, pair.position + velocity);
                }

                previousPair = pair;
            }
        }
    }
}
