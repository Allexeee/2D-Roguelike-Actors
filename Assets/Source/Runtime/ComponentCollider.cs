using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public struct ComponentCollider
	{
		public Collider2D collider;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Collider = "Roguelike.ComponentCollider";

		public static ref ComponentCollider ComponentCollider(in this ent entity) =>
			ref Storage<ComponentCollider>.components[entity.id];
	}

	sealed class StorageComponentCollider : Storage<ComponentCollider>
	{
		public override ComponentCollider Create() => new ComponentCollider();

		// Use for cleaning components that were removed at the current frame.
		public override void Dispose(indexes disposed)
		{
			foreach (var id in disposed)
			{
				ref var component = ref components[id];
			}
		}
	}

	#endregion
}