using System.Collections.Generic;
using UnityEngineAssets.Helpers;
using UnityEngine;

namespace UnityEngineAssets.Scripts.Tools
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(int.MaxValue)]
    [AddComponentMenu(ScriptHelpers.AddComponentMenuText.Components + "Transform Trail")]
    public class TransformTrail : MonoBehaviour
    {
        [SerializeField] private int m_trailCount;
        [SerializeField] private UpdateRate m_updateRate;
        private Queue<TransformTrailPair> m_trailQueue;

        public Queue<TransformTrailPair> TrailQueue { get => m_trailQueue; }
        public UpdateRate Rate { get => m_updateRate; }
        public int TrailCount { get => m_trailCount; }

        public enum UpdateRate { FixedUpdate, Update }

        private void Awake()
        {
            m_trailQueue = new Queue<TransformTrailPair>();
        }

        private void Update()
        {
            if (m_updateRate == UpdateRate.Update) TakeSnapshot();
        }

        private void FixedUpdate()
        {
            if (m_updateRate == UpdateRate.FixedUpdate) TakeSnapshot();
        }

        private void TakeSnapshot()
        {
            if (m_trailQueue.Count >= m_trailCount)
            {
                int length = m_trailQueue.Count - m_trailCount;
                for (int i = 0; i < length; i++) m_trailQueue.Dequeue();
            }

            m_trailQueue.Enqueue(new TransformTrailPair(transform));
        }
    }

    public struct TransformTrailPair
    {
        public readonly Quaternion rotation;
        public readonly Vector3 position;
        public readonly Vector3 up;

        public TransformTrailPair(Transform transform)
        {
            this.position = transform.position;
            this.rotation = transform.rotation;
            this.up = transform.up;
        }
    }
}
