//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

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

		public static bool HasSolidColliderInPoint(Vector2 pos, int mask, out ent entity)
		{
			entity = default;
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
	}
}