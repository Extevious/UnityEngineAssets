using System.Runtime.CompilerServices;

namespace UnityEngine {
    public static class ComponentExtensions {
        #region Position
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition (this Component component, Vector3 position) => component.transform.position = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition (this Component component, float x, float y, float z) => component.transform.position = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetPosition (this Component component, float x, float y) => component.transform.position = new Vector3(x, y, component.transform.localPosition.z);
        #endregion

        #region Local Position
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this Component component, Vector3 position) => component.transform.localPosition = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this Component component, float x, float y, float z) => component.transform.localPosition = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this Component component, float x, float y) => component.transform.localPosition = new Vector3(x, y, component.transform.localPosition.z);
        #endregion

        #region Local Scale
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this Component component, Vector3 scale) => component.transform.localScale = scale;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this Component component, float x, float y, float z) => component.transform.localScale = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this Component component, float x, float y) => component.transform.localScale = new Vector3(x, y, component.transform.localScale.z);
        #endregion

        #region Rotation
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetRotation (this Component component, Quaternion rotation) => component.transform.rotation = rotation;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetLocalRotation (this Component component, Quaternion rotation) => component.transform.localRotation = rotation;
        #endregion

        #region Rotation Euler
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetEulerAngles (this Component component, Vector3 target) => component.transform.eulerAngles = target;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalEulerAngles (this Component component, Vector3 target) => component.transform.localEulerAngles = target;
        #endregion
    }
}