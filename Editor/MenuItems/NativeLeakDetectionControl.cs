using Unity.Collections;
using UnityEditor;

namespace UnityEngineAssets.Editor {
    public static class NativeLeakDetectionControl {
        private const string _disabled = "Jobs/Native Leak Detection/Disabled";
        private const string _enabled = "Jobs/Native Leak Detection/Enabled";
        private const string _enabledWithStackTrace = "Jobs/Native Leak Detection/Enabled With Stack Trace";

        private const string _key = "LastNativeLeakDetectionSetting";

        [InitializeOnLoadMethod]
        private static void SetLastLeakDetectionValue () {
            if (EditorPrefs.HasKey(_key)) {
                int v = EditorPrefs.GetInt(_key);

                switch (v) {
                    case 1:
                        NoLeakDetection();
                        break;

                    case 2:
                        LeakDetection();
                        break;

                    case 3:
                        LeakDetectionWithStackTrace();
                        break;
                }

            } else {
                EditorPrefs.SetInt(_key, 2);
            }
        }

        [MenuItem(_disabled)]
        private static void NoLeakDetection () {
            NativeLeakDetection.Mode = NativeLeakDetectionMode.Disabled;

            Menu.SetChecked(_disabled, true);
            Menu.SetChecked(_enabled, false);
            Menu.SetChecked(_enabledWithStackTrace, false);

            EditorPrefs.SetInt(_key, 1);
        }

        [MenuItem(_enabled)]
        private static void LeakDetection () {
            NativeLeakDetection.Mode = NativeLeakDetectionMode.Enabled;

            Menu.SetChecked(_enabled, true);
            Menu.SetChecked(_disabled, false);
            Menu.SetChecked(_enabledWithStackTrace, false);

            EditorPrefs.SetInt(_key, 2);
        }

        [MenuItem(_enabledWithStackTrace)]
        private static void LeakDetectionWithStackTrace () {
            NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;

            Menu.SetChecked(_enabledWithStackTrace, true);
            Menu.SetChecked(_enabled, false);
            Menu.SetChecked(_disabled, false);

            EditorPrefs.SetInt(_key, 3);
        }
    }
}