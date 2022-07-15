using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEngineAssets.Helpers {
	public static class ScriptHelpers {
		public static class AddComponentMenuText {
			public const string Components = "Scripts/UnityEngineAssets/Components/";
			public const string Spawners = "Scripts/UnityEngineAssets/Spawners/";
			public const string Tools = "Scripts/UnityEngineAssets/Tools/";
		}

		private static void LogSingleInstancePerSceneError (string scriptName) => Debug.LogError($"Only a single instance of the {scriptName} component can be preset in a scene!");
		private static void LogComponentDoesNotExistInSceneError (string scriptName) => Debug.LogError($"An instance of the {scriptName} component does not exist in current scene! Creating one...");

		/// <summary>
		/// Returns <see langword="true"/> if the <see href="ComponentType"/> exists in the same scene.
		/// Option to log to console an error message when found.
		/// </summary>
		public static bool HasInstanceInScene<ComponentType> (Scene scene, ComponentType component, bool log = true) where ComponentType : Component {
			ComponentType[] components = Object.FindObjectsOfType<ComponentType>(true);

			// To avoid accidentally colliding with itself
			if (components.Length <= 1) return false;

			foreach (var obj in components) {
				if (obj.gameObject.scene.GetHashCode() == scene.GetHashCode()) {
					if (obj.GetInstanceID() == component.GetInstanceID()) continue;

					if (log) LogSingleInstancePerSceneError(typeof(ComponentType).Name);

					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Finds an instance of the type <see href="ComponentType"/> in the specified Scene.
		/// If one isn't found, it will be created and attach to a new <see cref="GameObject"/>.
		/// Option to log to console an error message when not found.
		/// </summary>
		public static ComponentType FindInstanceInSceneOrCreateNew<ComponentType> (Scene scene, bool log = true) where ComponentType : Component {
			ComponentType[] components = Object.FindObjectsOfType<ComponentType>(true);


			// If it exists, find it in the same scene.
			foreach (var obj in components) {
				if (obj.gameObject.scene.GetHashCode() == scene.GetHashCode()) return obj;
			}

			// It doesn't exist, so create a new one and add it to the scene.
			string name = typeof(ComponentType).Name;

			if (log) LogComponentDoesNotExistInSceneError(name);

			GameObject go = new GameObject(name);
			ComponentType results = go.AddComponent<ComponentType>();

			SceneManager.MoveGameObjectToScene(go, scene);

			return results;
		}
	}
}