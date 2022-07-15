using System.Runtime.CompilerServices;

namespace UnityEngineAssets.Unsafe {
	public static unsafe class BinaryConverter {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] ToBytes<T> (T value) where T : unmanaged {
			int length = sizeof(T);

			byte[] bytes = new byte[length];

			fixed (byte* target = bytes) {
				byte* source = (byte*)&value;

				for (int i = 0; i < length; i++) target[i] = source[i];
			}

			return bytes;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] ToBytes<T> (T value, int length) where T : unmanaged {
			byte[] bytes = new byte[length];

			fixed (byte* target = bytes) {
				byte* source = (byte*)&value;

				for (int i = 0; i < length; i++) target[i] = source[i];
			}

			return bytes;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToBytes<T> (byte[] destination, T value) where T : unmanaged {
			fixed (byte* t = destination) {
				byte* source = (byte*)&value;

				int length = sizeof(T);
				for (int i = 0; i < length; i++) t[i] = source[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToBytes<T> (byte[] destination, T value, int destinationOffset) where T : unmanaged {
			fixed (byte* t = destination) {
				byte* source = (byte*)&value;

				int length = sizeof(T);
				for (int i = 0; i < length; i++) t[i + destinationOffset] = source[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToBytes<T> (byte[] destination, T value, long destinationOffset) where T : unmanaged {
			fixed (byte* t = destination) {
				byte* source = (byte*)&value;

				long length = sizeof(T);
				for (long i = 0; i < length; i++) t[i + destinationOffset] = source[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FromBytes<T> (byte[] bytes) where T : unmanaged {
			T results = default;

			fixed (byte* source = bytes) {
				byte* target = (byte*)&results;

				int length = sizeof(T);
				for (int i = 0; i < length; i++) target[i] = source[i];
			}

			return results;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FromBytes<T> (byte[] bytes, int sourceOffset) where T : unmanaged {
			T results = default;

			fixed (byte* source = bytes) {
				byte* target = (byte*)&results;

				int length = sizeof(T);
				for (int i = 0; i < length; i++) target[i] = source[i + sourceOffset];
			}

			return results;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FromBytes<T> (byte[] bytes, long sourceOffset) where T : unmanaged {
			T results = default;

			fixed (byte* source = bytes) {
				byte* target = (byte*)&results;

				long length = sizeof(T);
				for (long i = 0; i < length; i++) target[i] = source[i + sourceOffset];
			}

			return results;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BytesCopy (byte[] source, int sourceIndex, byte[] target, int targetIndex) {
			fixed (byte* s = source, t = target) {
				for (int i = sourceIndex, m = targetIndex; i < source.LongLength; i++, m++) t[m] = s[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BytesCopy (byte[] source, long sourceIndex, byte[] target, long targetIndex) {
			fixed (byte* s = source, t = target) {
				for (long i = sourceIndex, m = targetIndex; i < source.LongLength; i++, m++) t[m] = s[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BytesCopy (byte[] source, int sourceIndex, int sourceLength, byte[] target, int targetIndex) {
			fixed (byte* s = source, t = target) {
				for (int i = sourceIndex, m = targetIndex; i < sourceLength; i++, m++) t[m] = s[i];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BytesCopy (byte[] source, long sourceIndex, long sourceLength, byte[] target, long targetIndex) {
			fixed (byte* s = source, t = target) {
				for (long i = sourceIndex, m = targetIndex; i < sourceLength; i++, m++) t[m] = s[i];
			}
		}
	}
}