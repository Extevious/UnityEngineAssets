using UnityEditor;
using UnityEngine;

namespace UnityEngineAssets.Editor {
    public static class EditorHelpers {
        public static class Gizmos {
            /// <summary>
            /// Draws a wire cube from two corners.
            /// </summary>
            public static void DrawWireCornerCube (Vector3 corner0, Vector3 corner1, Color color) {
                Vector3 center = corner0 + ((corner1 - corner0) / 2f);
                Vector3 size = corner1 - corner0;

                UnityEngine.Gizmos.color = color;
                UnityEngine.Gizmos.DrawWireCube(center, size);
            }

            /// <summary>
            /// Draws a cube from two corners.
            /// </summary>
            public static void DrawCornerCube (Vector3 corner0, Vector3 corner1, Color color) {
                Vector3 center = corner0 + ((corner1 - corner0) / 2f);
                Vector3 size = corner1 - corner0;

                UnityEngine.Gizmos.color = color;
                UnityEngine.Gizmos.DrawCube(center, size);
            }

        }

        public static class Handles {
            /// <summary>
            /// Returns true when a PositionHandle has been moved.
            /// </summary>
            public static bool PositionHandle (Object objectToUndo, Vector3 handlePosition, string handleName, out Vector3 newHandlePosition) {
                EditorGUI.BeginChangeCheck();
                newHandlePosition = UnityEditor.Handles.PositionHandle(handlePosition, Quaternion.identity);

                if (EditorGUI.EndChangeCheck()) {
                    Undo.RecordObject(objectToUndo, $"Modified {objectToUndo?.GetType().Name} {handleName}");
                    return true;
                }

                return false;
            }
        }

        public static class GUI {
            /// <summary>
            /// Renders a toggle button.
            /// </summary>
            public static void QuickToggleField (ref bool state, string label) => state = EditorGUILayout.ToggleLeft(label, state);

            /// <summary>
            /// Renders a bold label.
            /// </summary>
            public static void QuickBoldLabel (string label) => EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
        }
    }
}