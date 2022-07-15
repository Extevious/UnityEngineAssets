using Extevious.Curves;
using UnityEngineAssets.Helpers;
using UnityEngine;

// PURPOSE:
// Smoothly interpolate the attached Transform on a curve separately from the root Transform that is updated in FixedUpdate().
// Useful for camera tracking in competitive, high FPS games like: CS:GO, Overwatch, COD, etc.

// PROS:
// > Any method of smoothing that is called in an Update() or LateUpdate() can be used with no ill-effects.
//   However, it is highly recommended to use SmoothDamp() functions over Lerp() because of a slight "jello"
//   effect Lerp() generates when interpolating to its desired target.
// > Benefits of high framerate because the stepping is done in Update(), not FixedUpdate(). FixedUpdate() ticks
//   are usually around 30-60Hz, which wont look as good on a 120Hz+ display.

// CONS:
// > Requires a separate target Transform, preferably the root or parent Transform, to preform smoothing.
// > FPS drops might be noticed by the user, however all games suffer from some sort of momentary lag regardless.

// NOTES:
// > TransformInterpolation should always be last in the Script Execution Order. Otherwise, the script is working with
//   data that is a frame behind. Can be very noticeable on low-hz physic tick games (1-10hz especially, like EVE.)
//   The Script Execution Order is set automatically. To change the order, go to Script Execution Order in Project Settings.
// > It's best to cap framerate to a multiple of the physics tick rate, (such as 100, 150, 200, etc) if the fixed delta
//   is 50 per-second.
namespace UnityEngineAssets.Scripts.Components {
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(int.MaxValue)]
	[AddComponentMenu(ScriptHelpers.AddComponentMenuText.Components + "Transform Curve Interpolation")]
	public class TransformCurveInterpolation : MonoBehaviour {
		#region Fields and Properties
		[Tooltip("The Transform that is updated in a FixedUpdate() loop or by the physics engine. If this field is not assigned, the root transform will be used.")]
		[SerializeField] private Transform m_target;

		private Vector3[] m_targetPositions = new Vector3[3];
		private Quaternion[] m_targetRotations = new Quaternion[3];

		// Public properties
		public Transform Target { get => m_target; }
		#endregion

		#region Unity
		private void Reset () {
			if (transform.GetInstanceID() == transform.root.GetInstanceID()) {
				Debug.LogWarning("It is recommended to attach the Transform Interpolation Component to a child GameObject that targets the parent or root GameObject.");
			}
		}

		private void Awake () {
			if (m_target == null) {
				Debug.LogWarning($"The field \"{nameof(m_target)}\" Transform was not assigned. Using the root Transform instead.");
				m_target = transform.root;
			}
		}

		private void Start () {
			for (int i = 0; i < 3; i++) m_targetPositions[i] = m_target.position;
		}

		private void FixedUpdate () => Step();

		private void Update () => FixedToUpdateInterpolation();
		#endregion

		#region Methods
		private void Step () {
			m_targetPositions[0] = m_targetPositions[1];
			m_targetPositions[1] = m_targetPositions[2];
			m_targetPositions[2] = m_target.position;

			m_targetRotations[0] = m_targetRotations[1];
			m_targetRotations[1] = m_targetRotations[2];
			m_targetRotations[2] = m_target.rotation;
		}

		private void FixedToUpdateInterpolation () {
			// The delta time is calculated taking the current time and current fixed time since the
			// start of the game in double format for accurate time keeping. Time.deltaTime is not
			// used because this is calculating the time difference per-frame between two positions
			// from a FixedUpdate() loop, not the frame-specific delta from Update() or LateUpdate().
			float delta = (float)(Time.timeAsDouble - Time.fixedTimeAsDouble);

			// Example:
			// Starting and ending brackets represent the start and end of a frame. There is not
			// an actual "end" to a frame, but for representation purposes there is.

			// FixedUpdate() loop: [--][--][--][--][--][--][--][--]
			// Late/Update() loop: ][][-][][][--][][-][][-][][-][][

			// Notice how some frames overlap because of slight fluctuations in Time.deltaTime.
			// This is is why the delta between the two is calculated using the actual time since
			// the start of game relative to the update segment. The delta is NEVER negative, because
			// Update() and LateUpdate() is always called after FixedUpdate() by Unity internally.

			// t is technically supposed to be between 0f and 1f. Each 3 points makes 2 segments,
			// and the first point is needed as a control point. Offset by half, and making sure
			// delta scales accordingly.
			float deltaScale = delta / Time.fixedDeltaTime;
			float t = 0.5f + deltaScale * 0.5f;

			transform.position = CurveFunctions.ParametricCurve(m_targetPositions[0], m_targetPositions[1], m_targetPositions[2], 0.5f, t);
			transform.rotation = Quaternion.SlerpUnclamped(m_targetRotations[1], m_targetRotations[2], deltaScale);
		}

		/// <summary>
		/// Sets the target Transform.
		/// </summary>
		public Transform SetTargetTransform (Transform target) => m_target = target;
		#endregion
	}
}