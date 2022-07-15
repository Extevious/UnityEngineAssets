using System.Runtime.CompilerServices;

// Vector2Int conversions
namespace UnityEngine {
	public static partial class Convert {
		// Vector..
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector3 (this Vector2Int f) => new Vector3(f.x, f.y, 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 ToVector4 (this Vector2Int f) => new Vector4(f.x, f.y, 0f, 0f);

		// Vector..Int
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int ToVector3Int (this Vector2Int f) => new Vector3Int(f.x, f.y, 0);
	}
}
