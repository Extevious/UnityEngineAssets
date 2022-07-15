using UnityEngineAssets.Helpers;
using UnityEngine;

namespace UnityEngineAssets.Scripts.Components {
	[DisallowMultipleComponent]
	[AddComponentMenu(ScriptHelpers.AddComponentMenuText.Components + "Auto Detacher")]
	public class AutoDetacher : MonoBehaviour {
		[Tooltip("The Transform to set as a parent. Keep null for default detachment.")]
		[SerializeField] private Transform m_optionalTarget;
		[Tooltip("When detachment should be executed.")]
		[SerializeField] private AutoDetachOn m_when;
		[Tooltip("Auto-destroy this Component.")]
		[SerializeField] private bool m_autoDestroy = true;

		public enum AutoDetachOn { Awake, Start, OnEnable, OnDisable }

		private void Awake () {
			if (m_when == AutoDetachOn.Awake) {
				transform.SetParent(m_optionalTarget);
				if (m_autoDestroy) Destroy(this);
			}
		}

		private void Start () {
			if (m_when == AutoDetachOn.Start) {
				transform.SetParent(m_optionalTarget);
				if (m_autoDestroy) Destroy(this);
			}
		}

		private void OnEnable () {
			if (m_when == AutoDetachOn.OnEnable) {
				transform.SetParent(m_optionalTarget);
				if (m_autoDestroy) Destroy(this);
			}
		}

		private void OnDisable () {
			if (m_when == AutoDetachOn.OnDisable) {
				transform.SetParent(m_optionalTarget);
				if (m_autoDestroy) Destroy(this);
			}
		}
	}
}