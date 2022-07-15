using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public static class ComponentExtensions
    {

        #region Position
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition(this Component component, Vector3 position) => component.transform.position = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition(this Component component, float x, float y, float z) => component.transform.position = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition(this Component component, float x, float y) => component.transform.position = new Vector3(x, y, component.transform.localPosition.z);
        #endregion

        #region Local Position
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition(this Component component, Vector3 position) => component.transform.localPosition = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition(this Component component, float x, float y, float z) => component.transform.localPosition = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition(this Component component, float x, float y) => component.transform.localPosition = new Vector3(x, y, component.transform.localPosition.z);
        #endregion

        #region Local Scale
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale(this Component component, Vector3 scale) => component.transform.localScale = scale;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale(this Component component, float x, float y, float z) => component.transform.localScale = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale(this Component component, float x, float y) => component.transform.localScale = new Vector3(x, y, component.transform.localScale.z);
        #endregion

        #region Rotation
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetRotation(this Component component, Quaternion rotation) => component.transform.rotation = rotation;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetLocalRotation(this Component component, Quaternion rotation) => component.transform.localRotation = rotation;
        #endregion

        #region Rotation Euler
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetEulerAngles(this Component component, Vector3 euler) => component.transform.eulerAngles = euler;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalEulerAngles(this Component component, Vector3 euler) => component.transform.localEulerAngles = euler;
        #endregion

        #region Lerp Position
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToPosition(this Component component, Vector3 target, float f) => component.transform.position = Vector3.Lerp(component.transform.position, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalPosition(this Component component, Vector3 target, float f) => component.transform.localPosition = Vector3.Lerp(component.transform.localPosition, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToPositionUnclamped(this Component component, Vector3 target, float f) => component.transform.position = Vector3.Lerp(component.transform.position, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalPositionUnclamped(this Component component, Vector3 target, float f) => component.transform.localPosition = Vector3.LerpUnclamped(component.transform.localPosition, target, f);
        #endregion

        #region Lerp Rotation
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion LerpToRotation(this Component component, Quaternion target, float f) => component.transform.rotation = Quaternion.Lerp(component.transform.rotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion LerpToRotationUnclamped(this Component component, Quaternion target, float f) => component.transform.rotation = Quaternion.LerpUnclamped(component.transform.rotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion LerpToLocalRotation(this Component component, Quaternion target, float f) => component.transform.localRotation = Quaternion.Lerp(component.transform.localRotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion LerpToLocalRotationUnclamped(this Component component, Quaternion target, float f) => component.transform.localRotation = Quaternion.LerpUnclamped(component.transform.localRotation, target, f);
        #endregion

        #region Slerp Rotation
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SlerpToRotation(this Component component, Quaternion target, float f) => component.transform.rotation = Quaternion.Slerp(component.transform.rotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SlerpToRotationUnclamped(this Component component, Quaternion target, float f) => component.transform.rotation = Quaternion.SlerpUnclamped(component.transform.rotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SlerpToLocalRotation(this Component component, Quaternion target, float f) => component.transform.localRotation = Quaternion.Slerp(component.transform.localRotation, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SlerpToLocalRotationUnclamped(this Component component, Quaternion target, float f) => component.transform.localRotation = Quaternion.SlerpUnclamped(component.transform.localRotation, target, f);
        #endregion

        #region Rotation Euler
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToEuler(this Component component, Vector3 target, float f) => component.transform.eulerAngles = Vector3.Lerp(component.transform.eulerAngles, target, f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToEulerUnclamped(this Component component, Vector3 target, float f) => component.transform.eulerAngles = Vector3.LerpUnclamped(component.transform.eulerAngles, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalEuler(this Component component, Vector3 target, float f) => component.transform.localEulerAngles = Vector3.Lerp(component.transform.localEulerAngles, target, f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalEulerUnclamped(this Component component, Vector3 target, float f) => component.transform.localEulerAngles = Vector3.LerpUnclamped(component.transform.localEulerAngles, target, f);
        #endregion

        #region Scale
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalScale(this Component component, Vector3 target, float f) => component.transform.localScale = Vector3.Lerp(component.transform.localScale, target, f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 LerpToLocalScaleUnclamped(this Component component, Vector3 target, float f) => component.transform.localScale = Vector3.LerpUnclamped(component.transform.localScale, target, f);
        #endregion

        #region Rotation Euler Stripping
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerX(this Component component) => component.transform.rotation = Quaternion.Euler(0f, component.transform.eulerAngles.y, component.transform.eulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerY(this Component component) => component.transform.rotation = Quaternion.Euler(component.transform.eulerAngles.x, 0f, component.transform.eulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerZ(this Component component) => component.transform.rotation = Quaternion.Euler(component.transform.eulerAngles.x, component.transform.eulerAngles.y, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerXY(this Component component) => component.transform.rotation = Quaternion.Euler(0f, 0f, component.transform.eulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerYZ(this Component component) => component.transform.rotation = Quaternion.Euler(component.transform.eulerAngles.x, 0f, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripRotationEulerXZ(this Component component) => component.transform.rotation = Quaternion.Euler(0f, component.transform.eulerAngles.y, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerX(this Component component) => component.transform.localRotation = Quaternion.Euler(0f, component.transform.localEulerAngles.y, component.transform.localEulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerY(this Component component) => component.transform.localRotation = Quaternion.Euler(component.transform.localEulerAngles.x, 0f, component.transform.localEulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerZ(this Component component) => component.transform.localRotation = Quaternion.Euler(component.transform.localEulerAngles.x, component.transform.localEulerAngles.y, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerXY(this Component component) => component.transform.localRotation = Quaternion.Euler(0f, 0f, component.transform.localEulerAngles.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerYZ(this Component component) => component.transform.localRotation = Quaternion.Euler(component.transform.localEulerAngles.x, 0f, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion StripLocalRotationEulerXZ(this Component component) => component.transform.localRotation = Quaternion.Euler(0f, component.transform.localEulerAngles.y, 0f);
        #endregion
    }
}