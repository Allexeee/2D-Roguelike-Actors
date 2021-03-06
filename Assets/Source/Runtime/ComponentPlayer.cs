﻿//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
	public class ComponentPlayer
	{
		public ent observer = default;
	}

	#region HELPERS

	static partial class Component
	{
		public const string Player = "Roguelike.ComponentPlayer";

		public static ref ComponentPlayer ComponentPlayer(in this ent entity) =>
			ref Storage<ComponentPlayer>.components[entity.id];
	}

	sealed class StorageComponentPlayer : Storage<ComponentPlayer>
	{
		public override ComponentPlayer Create() => new ComponentPlayer();

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