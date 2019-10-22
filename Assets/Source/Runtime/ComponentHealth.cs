//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
	public class ComponentHealth
	{
		public int count;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Health = "Roguelike.ComponentHealth";

		public static ref ComponentHealth ComponentHealth(in this ent entity) =>
			ref Storage<ComponentHealth>.components[entity.id];
	}

	sealed class StorageComponentHealth : Storage<ComponentHealth>
	{
		public override ComponentHealth Create() => new ComponentHealth();

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