using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentRenderer
	{
		public SpriteRenderer source;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Renderer = "Roguelike.ComponentRenderer";

		public static ref ComponentRenderer ComponentRenderer(in this ent entity) =>
			ref Storage<ComponentRenderer>.components[entity.id];
	}

	sealed class StorageComponentRenderer : Storage<ComponentRenderer>
	{
		public override ComponentRenderer Create() => new ComponentRenderer();

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