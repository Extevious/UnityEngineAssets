using UnityEngineAssets.Helpers;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace UnityEngineAssets.Scripts.Components {
	[DefaultExecutionOrder(int.MaxValue - 2)]
	[AddComponentMenu(ScriptHelpers.AddComponentMenuText.Components + "Physics Runtime")]
	public class PhysicsRuntime : MonoBehaviour {
		private PhysicsScene m_physicsScene;

		public PhysicsScene PhysicsScene { get => m_physicsScene; }

		public event Action onPreSimulate;
		public event Action onPostSimulate;

		private void Reset () {
			if (ScriptHelpers.HasInstanceInScene<PhysicsRuntime>(gameObject.scene, this)) {
				DestroyImmediate(this);
				return;
			}
		}

		private void Awake () => m_physicsScene = gameObject.scene.GetPhysicsScene();

		private void FixedUpdate () {
			onPreSimulate?.Invoke();
			m_physicsScene.Simulate(Time.fixedDeltaTime);
			onPostSimulate?.Invoke();
		}

		public static PhysicsRuntime GetInstanceInScene (Scene scene) => ScriptHelpers.FindInstanceInSceneOrCreateNew<PhysicsRuntime>(scene);
	}
}
