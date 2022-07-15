using System.Runtime.CompilerServices;

// Vector3Int conversions
namespace UnityEngine {
	public static partial class Convert {
		// Vector..
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ToVector2 (this Vector3Int f) => new Vector2(f.x, f.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector3 (this Vector3Int f) => new Vector3(f.x, f.y, f.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 ToVector4 (this Vector3Int f) => new Vector4(f.x, f.y, f.z, 0f);

		// Vector..Int
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2Int ToVector2Int (this Vector3Int f) => new Vector2Int(f.x, f.y);
	}
}
