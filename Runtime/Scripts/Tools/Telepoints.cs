using System;
using UnityEngineAssets.Helpers;
using UnityEngine;

namespace UnityEngineAssets.Scripts.Tools
{
    [DisallowMultipleComponent]
    [AddComponentMenu(ScriptHelpers.AddComponentMenuText.Tools + "Telepoints")]
    public class Telepoints : MonoBehaviour
    {
        [Tooltip("The optional Transform to teleport. If left null, the Transform this Component is attached to will be used instead.")]
        [SerializeField] private Transform m_optionalTarget;
        [Tooltip("The interval in seconds when to teleport the Transform.")]
        [SerializeField] private float m_delay = 0.4f;
        [Tooltip("The seeder value to initialize the Random Number Generator.")]
        [SerializeField] private int m_seed = 1234;
        [SerializeField] private Vector3 m_corner0 = Vector3.one * 5f;
        [SerializeField] private Vector3 m_corner1 = Vector3.one * 25;

        private float m_time;

        public event Action<Vector3> onTeleportEvent;

        public Vector3 Corner0 { get => m_corner0; set => m_corner0 = value; }
        public Vector3 Corner1 { get => m_corner1; set => m_corner1 = value; }

        private void OnValidate()
        {
            if (m_delay <= 0.001f) m_delay = 0.001f;
        }

        private void Awake()
        {
            if (m_optionalTarget == null)
            {
                Debug.LogWarning("OptionalTarget was not assigned. Using attached Transform instead.");
                m_optionalTarget = transform;
            }

            UnityEngine.Random.InitState(m_seed);
        }

        private void Update()
        {
            if (m_time > m_delay)
            {
                m_time = 0f;

                if (m_optionalTarget == null) return;

                Vector3 nextPosition;
                nextPosition.x = UnityEngine.Random.Range(m_corner0.x, m_corner1.x);
                nextPosition.y = UnityEngine.Random.Range(m_corner0.y, m_corner1.y);
                nextPosition.z = UnityEngine.Random.Range(m_corner0.z, m_corner1.z);

                m_optionalTarget.position = nextPosition;

                onTeleportEvent?.Invoke(nextPosition);
            }

            m_time += Time.deltaTime;
        }
    }
}
