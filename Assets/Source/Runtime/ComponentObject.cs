
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentObject
	{
		public Vector3 position;
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