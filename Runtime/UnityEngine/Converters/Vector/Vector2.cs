using System.Runtime.CompilerServices;

// Vector2 conversions
namespace UnityEngine {
	public static partial class Convert {
		// Vector..
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector3 (this Vector2 f) => new Vector3(f.x, f.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 ToVector4 (this Vector2 f) => new Vector4(f.x, f.y, 0f, 0f);

		// Vector..Int
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2Int ToVector2Int (this Vector2 f) => new Vector2Int((int)f.x, (int)f.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int ToVector3Int (this Vector2 f) => new Vector3Int((int)f.x, (int)f.y, 0);
	}
}
