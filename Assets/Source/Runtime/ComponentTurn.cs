using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentTurn
	{
	}

	#region HELPERS

	static partial class Component
	{
		public const string Turn = "Roguelike.ComponentTurn";

		public static ref ComponentTurn ComponentTurn(in this ent entity) =>
			ref Storage<ComponentTurn>.components[entity.id];
	}

	sealed class StorageComponentTurn : Storage<ComponentTurn>
	{
		public override ComponentTurn Create() => new ComponentTurn();

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