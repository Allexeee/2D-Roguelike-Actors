using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentFood
	{
		public int count;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Food = "Roguelike.ComponentFood";

		public static ref ComponentFood ComponentFood(in this ent entity) =>
			ref Storage<ComponentFood>.components[entity.id];
	}

	sealed class StorageComponentFood : Storage<ComponentFood>
	{
		public override ComponentFood Create() => new ComponentFood();

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