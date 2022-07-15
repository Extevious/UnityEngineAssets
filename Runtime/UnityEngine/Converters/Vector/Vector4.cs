using System.Runtime.CompilerServices;

// Vector4 conversions
namespace UnityEngine {
	public static partial class Convert {
		// Vector..
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ToVector2 (this Vector4 f) => new Vector2(f.x, f.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector3 (this Vector4 f) => new Vector3(f.x, f.y, f.z);

		// Vector..Int
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2Int ToVector2Int (this Vector4 f) => new Vector2Int((int)f.x, (int)f.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int ToVector3Int (this Vector4 f) => new Vector3Int((int)f.x, (int)f.y, (int)f.z);
	}
}
