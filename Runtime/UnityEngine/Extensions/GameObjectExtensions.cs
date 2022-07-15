using System.Runtime.CompilerServices;

namespace UnityEngine {
    public static class GameObjectExtensions {

        #region Position        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Position (this GameObject gameObject, Vector3 position) => gameObject.transform.position = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Position (this GameObject gameObject, float x, float y, float z) => gameObject.transform.position = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Position (this GameObject gameObject, float x, float y) => gameObject.transform.position = new Vector3(x, y, gameObject.transform.localPosition.z);
        #endregion

        #region Local Position        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this GameObject gameObject, Vector3 position) => gameObject.transform.localPosition = position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this GameObject gameObject, float x, float y, float z) => gameObject.transform.localPosition = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalPosition (this GameObject gameObject, float x, float y) => gameObject.transform.localPosition = new Vector3(x, y, gameObject.transform.localPosition.z);
        #endregion

        #region Local Scale        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this GameObject gameObject, Vector3 scale) => gameObject.transform.localScale = scale;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this GameObject gameObject, float x, float y, float z) => gameObject.transform.localScale = new Vector3(x, y, z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SetLocalScale (this GameObject gameObject, float x, float y) => gameObject.transform.localScale = new Vector3(x, y, gameObject.transform.localScale.z);
        #endregion

        #region Rotation        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetRotation (this GameObject gameObject, Quaternion rotation) => gameObject.transform.rotation = rotation;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion SetLocalRotation (this GameObject gameObject, Quaternion rotation) => gameObject.transform.localRotation = rotation;
        #endregion

        #region States        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsActive (this GameObject gameObject) => gameObject.activeSelf || gameObject.activeInHierarchy;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetStatic (this GameObject gameObject, bool state) => gameObject.isStatic = state;
        #endregion

        #region Naming        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SetName (this GameObject gameObject, string name) => gameObject.name = name;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SetTag (this GameObject gameObject, string tag) => gameObject.tag = tag;
        #endregion
    }
}