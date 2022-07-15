using UnityEngineAssets.Helpers;
using UnityEngine;

namespace UnityEngineAssets.Scripts.Tools
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [AddComponentMenu(ScriptHelpers.AddComponentMenuText.Tools + "Ping Pong")]
    public class PingPong : MonoBehaviour
    {
        [Tooltip("First position.")]
        [SerializeField] private Vector3 m_A = new Vector3(-5f, -2f, 0f);
        [Tooltip("Second position.")]
        [SerializeField] private Vector3 m_B = new Vector3(5f, 2f, 0f);
        [Tooltip("The rate of change between positions.")]
        [SerializeField] private float m_rate = 10f;
        [Tooltip("The type of movement between positions.")]
        [SerializeField] private _MoveType m_moveType = _MoveType.Linear;
        [Tooltip("Which update loop to process the PingPong in.")]
        [SerializeField] private _UpdateRate m_updateRate = _UpdateRate.Paused;

        public enum _MoveType { Linear, Damp, Lerp, Teleport }
        public enum _UpdateRate { Paused, Editor, FixedUpdate, Update, LateUpdate }

        private Vector3 m_velocity; // Only because SmoothDamp needs it.
        private Vector3 m_position; // Exists only because I wanted Teleporting.
        private Vector3 m_current;
        private Vector3 m_last;
        private bool m_flip;

        public Vector3 PositionA { get => m_A; set => m_A = value; }
        public Vector3 PositionB { get => m_B; set => m_B = value; }
        public float Rate { get => m_rate; set => m_rate = value; }
        public _MoveType MoveType { get => m_moveType; set => m_moveType = value; }
        public _UpdateRate UpdateRate { get => m_updateRate; set => m_updateRate = value; }

        private void OnValidate()
        {
            if (m_flip)
            {
                m_current = m_A;
                m_last = m_B;

            }
            else
            {
                m_current = m_B;
                m_last = m_A;
            }
        }

        private void Reset()
        {
            m_current = m_A;
            m_last = m_B;
        }

        private void Awake()
        {
            m_current = m_A;
            m_last = m_B;
        }

        private void FixedUpdate()
        {
            if (m_updateRate == _UpdateRate.FixedUpdate) PingPongPingPong(Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (m_updateRate == _UpdateRate.Update && Application.isPlaying) PingPongPingPong(Time.deltaTime);
            else if (m_updateRate == _UpdateRate.Editor && !Application.isPlaying) PingPongPingPong(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (m_updateRate == _UpdateRate.LateUpdate) PingPongPingPong(Time.deltaTime);
        }

        private void PingPongPingPong(float delta)
        {
            if (Vector3.Distance(m_position, m_current) < 0.05f)
            {
                transform.localPosition = m_position;
                m_flip = !m_flip;

                Vector3 last = m_last;
                m_last = m_current;
                m_current = last;
            }

            switch (m_moveType)
            {
                case _MoveType.Linear:
                    m_position = Vector3.MoveTowards(m_position, m_current, m_rate * delta);
                    transform.localPosition = m_position;
                    break;

                case _MoveType.Damp:
                    m_position = Vector3.SmoothDamp(m_position, m_current, ref m_velocity, m_rate, float.MaxValue, delta);
                    transform.localPosition = m_position;
                    break;

                case _MoveType.Lerp:
                    m_position = Vector3.Lerp(m_position, m_current, m_rate * delta);
                    transform.localPosition = m_position;
                    break;

                default:
                    m_position = Vector3.MoveTowards(m_position, m_current, m_rate * delta);
                    break;
            }
        }

        public void EditorUpdate()
        {
            if (m_flip)
            {
                m_current = m_A;
                m_last = m_B;

            }
            else
            {
                m_current = m_B;
                m_last = m_A;
            }
        }
    }
}
