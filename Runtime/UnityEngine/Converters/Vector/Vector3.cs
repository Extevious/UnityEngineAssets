using System.Runtime.CompilerServices;

// Vector3 conversions
namespace UnityEngine {
	public static partial class Convert {
		// Vector..Int
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2Int ToVector2Int (this Vector3 f) => new Vector2Int((int)f.x, (int)f.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int ToVector3Int (this Vector3 f) => new Vector3Int((int)f.x, (int)f.y, (int)f.z);
	}
}
