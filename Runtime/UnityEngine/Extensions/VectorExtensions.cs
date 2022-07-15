using System.Runtime.CompilerServices;

namespace UnityEngine {
	public static class VectorExtensions {
		#region Vector3 Stripping
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripX (this Vector3 vector) => new Vector3(0f, vector.y, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripY (this Vector3 vector) => new Vector3(vector.x, 0f, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripZ (this Vector3 vector) => new Vector3(vector.x, vector.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripXY (this Vector3 vector) => new Vector3(0f, 0f, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripYZ (this Vector3 vector) => new Vector3(vector.x, 0f, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 StripXZ (this Vector3 vector) => new Vector3(0f, vector.y, 0f);
		#endregion

		#region Vector3 Flipping
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXY (this Vector3 vector) => new Vector3(vector.y, vector.x, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXZ (this Vector3 vector) => new Vector3(vector.z, vector.y, vector.x);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipYZ (this Vector3 vector) => new Vector3(vector.x, vector.z, vector.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXY (this Vector3 vector, float newSignX = 1f, float newSignY = 1f) => new Vector3(vector.y * newSignX, vector.x * newSignY, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXZ (this Vector3 vector, float newSignX = 1f, float newSignZ = 1f) => new Vector3(vector.z * newSignX, vector.y, vector.x * newSignZ);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipYZ (this Vector3 vector, float newSignY = 1f, float newSignZ = 1f) => new Vector3(vector.x, vector.z * newSignY, vector.y * newSignZ);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXYsX (this Vector3 vector, float newSignX = 1f) => new Vector3(vector.y * newSignX, vector.x, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXZsX (this Vector3 vector, float newSignX = 1f) => new Vector3(vector.z * newSignX, vector.y, vector.x);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipYZsY (this Vector3 vector, float newSignY = 1f) => new Vector3(vector.x, vector.z * newSignY, vector.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXYsY (this Vector3 vector, float newSignY = 1f) => new Vector3(vector.y, vector.x * newSignY, vector.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipXZsZ (this Vector3 vector, float newSignZ = 1f) => new Vector3(vector.z, vector.y, vector.x * newSignZ);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FlipYZsZ (this Vector3 vector, float newSignZ = 1f) => new Vector3(vector.x, vector.z, vector.y * newSignZ);
		#endregion
	}
}