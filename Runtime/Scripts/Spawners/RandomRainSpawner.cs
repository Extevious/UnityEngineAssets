using System.Collections.Generic;
using UnityEngine;
using UnityEngineAssets.Helpers;
using System.Collections;
using UnityEngine.Pool;

namespace UnityEngineAssets.Scripts.Spawners {
	[AddComponentMenu(ScriptHelpers.AddComponentMenuText.Spawners + "Random Rain Spawner")]
	public class RandomRainSpawner : MonoBehaviour {
		[SerializeField] private int m_maxCount = 30;
		[SerializeField] private float m_spawnDelay = 0.1f;
		[SerializeField] private float m_speed = -15f;
		[SerializeField] private float m_scale = 1f;

		[SerializeField] private Vector3 m_corner0 = Vector3.one * 5f;
		[SerializeField] private Vector3 m_corner1 = Vector3.one * 25f;
		[SerializeField] private GameObject m_optionalPrefab;

		private ObjectPool<GameObject> m_pool;
		private List<GameObject> m_gameObjects = new List<GameObject>();

		public Vector3 Corner0 { get => m_corner0; set => m_corner0 = value; }
		public Vector3 Corner1 { get => m_corner1; set => m_corner1 = value; }

		private GameObject OnEmptyPool () {
			GameObject go;

			if (m_optionalPrefab != null) {
				go = Instantiate(m_optionalPrefab);

			} else {
				int rand = Random.Range(0, 3);

				switch (rand) {
					case 0: go = GameObject.CreatePrimitive(PrimitiveType.Capsule); break;
					case 1: go = GameObject.CreatePrimitive(PrimitiveType.Cube); break;
					case 2: go = GameObject.CreatePrimitive(PrimitiveType.Cylinder); break;
					default: go = GameObject.CreatePrimitive(PrimitiveType.Sphere); break;
				}
			}

			if (go.TryGetComponent<MeshRenderer>(out MeshRenderer renderer)) {
				renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
			}

			return go;
		}

		private void Awake () {
			m_pool = new ObjectPool<GameObject>(OnEmptyPool, null, null, (GameObject go) => Destroy(go));
			if (m_optionalPrefab == null) Debug.LogWarning("Optional prefab was not assigned. Spawning primitives instead. Click \"Clear Pool and GameObjects\" button to purge when assigning prefab during runtime.");
		}

		private void Start () {
			StartCoroutine(_SpawnLoop());
		}

		private void FixedUpdate () {
			Vector3 direction = new Vector3(0f, m_speed * Time.fixedDeltaTime, 0f);

			float y1 = (m_corner0.y < m_corner1.y) ? m_corner0.y : m_corner1.y;
			float y2 = (m_corner0.y > m_corner1.y) ? m_corner0.y : m_corner1.y;

			for (int i = 0; i < m_gameObjects.Count; i++) {
				GameObject go = m_gameObjects[i];

				if (go.transform.position.y < y1 || go.transform.position.y > y2) {
					m_gameObjects.Remove(go);
					go.SetActive(false);
					m_pool.Release(go);
					i--;

					if (m_gameObjects.Count == 0) return;
				}

				go.transform.position += direction;
			}
		}

		public void ClearPoolAndGameObjects () {
			foreach (var go in m_gameObjects) m_pool.Release(go);
			m_gameObjects.Clear();

			m_pool.Clear();
		}

		private IEnumerator _SpawnLoop () {
			while (true) {
				if (m_gameObjects.Count >= m_maxCount) {
					yield return new WaitForSeconds(m_spawnDelay);
					continue;
				}

				GameObject go = m_pool.Get();
				go.SetActive(true);

				float x = Random.Range(m_corner1.x, m_corner0.x);
				float z = Random.Range(m_corner1.z, m_corner0.z);

				float y = 0f;

				if (m_corner1.y > m_corner0.y) {
					y = (System.Math.Sign(m_speed) == -1) ? m_corner1.y : m_corner0.y;

				} else {
					y = (System.Math.Sign(m_speed) == -1) ? m_corner0.y : m_corner1.y;
				}

				go.transform.position = new Vector3(x, y, z);
				go.transform.localScale = Vector3.one * m_scale;

				m_gameObjects.Add(go);

				yield return new WaitForSeconds(m_spawnDelay);
			}
		}
	}
}