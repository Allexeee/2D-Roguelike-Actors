//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentObject
	{
		public Vector3 position;

		public Collider2D collider;
		public SpriteRenderer renderer;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Object = "Roguelike.ComponentObject";

		public static ref ComponentObject ComponentObject(in this ent entity) =>
			ref Storage<ComponentObject>.components[entity.id];
	}

	sealed class StorageComponentObject : Storage<ComponentObject>
	{
		public override ComponentObject Create() => new ComponentObject();

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