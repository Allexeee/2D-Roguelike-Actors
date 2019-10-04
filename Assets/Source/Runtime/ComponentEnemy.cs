using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public struct ComponentEnemy
	{
		
	}

	#region HELPERS

	static partial class Component
	{
		public const string Enemy = "Roguelike.ComponentEnemy";

		public static ref ComponentEnemy ComponentEnemy(in this ent entity) =>
			ref Storage<ComponentEnemy>.components[entity.id];
	}

	sealed class StorageComponentEnemy : Storage<ComponentEnemy>
	{
		public override ComponentEnemy Create() => new ComponentEnemy();

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