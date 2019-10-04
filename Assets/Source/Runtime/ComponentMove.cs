
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentMove
	{
		public Vector2 target;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Move = "Roguelike.ComponentMove";

		public static ref ComponentMove ComponentMove(in this ent entity) =>
			ref Storage<ComponentMove>.components[entity.id];
	}

	sealed class StorageComponentMove : Storage<ComponentMove>
	{
		public override ComponentMove Create() => new ComponentMove();

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