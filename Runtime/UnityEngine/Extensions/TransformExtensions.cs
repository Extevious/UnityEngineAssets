using System.Runtime.CompilerServices;

namespace UnityEngine {
	public static partial class TransformExtensions {

		#region Lerp Position
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToPosition (this Transform transform, Vector3 target, float f) => transform.position = Vector3.Lerp(transform.position, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalPosition (this Transform transform, Vector3 target, float f) => transform.localPosition = Vector3.Lerp(transform.localPosition, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToPositionUnclamped (this Transform transform, Vector3 target, float f) => transform.position = Vector3.Lerp(transform.position, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalPositionUnclamped (this Transform transform, Vector3 target, float f) => transform.localPosition = Vector3.LerpUnclamped(transform.localPosition, target, f);
		#endregion

		#region Lerp Rotation
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion LerpToRotation (this Transform transform, Quaternion target, float f) => transform.rotation = Quaternion.Lerp(transform.rotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion LerpToRotationUnclamped (this Transform transform, Quaternion target, float f) => transform.rotation = Quaternion.LerpUnclamped(transform.rotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion LerpToLocalRotation (this Transform transform, Quaternion target, float f) => transform.localRotation = Quaternion.Lerp(transform.localRotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion LerpToLocalRotationUnclamped (this Transform transform, Quaternion target, float f) => transform.localRotation = Quaternion.LerpUnclamped(transform.localRotation, target, f);
		#endregion

		#region Slerp Rotation
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion SlerpToRotation (this Transform transform, Quaternion target, float f) => transform.rotation = Quaternion.Slerp(transform.rotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion SlerpToRotationUnclamped (this Transform transform, Quaternion target, float f) => transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion SlerpToLocalRotation (this Transform transform, Quaternion target, float f) => transform.localRotation = Quaternion.Slerp(transform.localRotation, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion SlerpToLocalRotationUnclamped (this Transform transform, Quaternion target, float f) => transform.localRotation = Quaternion.SlerpUnclamped(transform.localRotation, target, f);
		#endregion

		#region Rotation Euler
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToEuler (this Transform transform, Vector3 target, float f) => transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, target, f);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToEulerUnclamped (this Transform transform, Vector3 target, float f) => transform.eulerAngles = Vector3.LerpUnclamped(transform.eulerAngles, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalEuler (this Transform transform, Vector3 target, float f) => transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, target, f);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalEulerUnclamped (this Transform transform, Vector3 target, float f) => transform.localEulerAngles = Vector3.LerpUnclamped(transform.localEulerAngles, target, f);
		#endregion

		#region Scale
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalScale (this Transform transform, Vector3 target, float f) => transform.localScale = Vector3.Lerp(transform.localScale, target, f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpToLocalScaleUnclamped (this Transform transform, Vector3 target, float f) => transform.localScale = Vector3.LerpUnclamped(transform.localScale, target, f);
		#endregion

		#region Rotation Euler Stripping
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerX (this Transform transform) => transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, transform.eulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerY (this Transform transform) => transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0f, transform.eulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerZ (this Transform transform) => transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerXY (this Transform transform) => transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerYZ (this Transform transform) => transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0f, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripRotationEulerXZ (this Transform transform) => transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerX (this Transform transform) => transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y, transform.localEulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerY (this Transform transform) => transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 0f, transform.localEulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerZ (this Transform transform) => transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerXY (this Transform transform) => transform.localRotation = Quaternion.Euler(0f, 0f, transform.localEulerAngles.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerYZ (this Transform transform) => transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 0f, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion StripLocalRotationEulerXZ (this Transform transform) => transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
		#endregion
	}
}