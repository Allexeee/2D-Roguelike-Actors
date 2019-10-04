using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;

namespace Roguelike
{
	public static class Phys
	{
		public static readonly BufferSortedEntities buffer = new BufferSortedEntities(256);

		public static readonly RaycastHit2D[] hits = new RaycastHit2D[64];
		public static readonly Collider2D[] colliders = new Collider2D[64];

		public static int OverlapPoint2D(Vector2 pos, int mask = 1 << 0, float min = float.NegativeInfinity, float max = float.PositiveInfinity)
		{
			return Physics2D.OverlapPointNonAlloc(pos, colliders, mask, min, max);
		}

		public static bool HasColliderInPoint(Vector2 pos, int mask, out ent entity)
		{
			entity = -1;
			var hit = OverlapPoint2D(pos, mask);
			if (hit > 0)
			{
				var index = HelperArray.BinarySearch(ref buffer.pointers, colliders[0].GetHashCode(), 0, buffer.length);
				if (index != -1)
					entity = buffer.entities[index];
				if (colliders[0].isTrigger)
					return false;

				return true;
			}

			return false;
		}


		public static ent GetEntity<T>(Vector2 position, Vector2 direction, float distance, int mask)
		{
			var hit = Physics2D.Raycast(position, direction, distance, mask);
			if (hit)
			{
				var index = HelperArray.BinarySearch(ref buffer.pointers, hit.collider.GetHashCode(), 0, buffer.length);
				if (index == -1)
					return default;

				ref var nextEntity = ref buffer.entities[index];
				if (nextEntity.Has<T>())
					return nextEntity;
			}

			return -1;
		}
	}
}