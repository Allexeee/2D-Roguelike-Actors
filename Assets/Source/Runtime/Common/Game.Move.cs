//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Game
	{
		public static void MoveTo(ent entity, Vector2 target)
		{
			ref var cObject = ref entity.ComponentObject();
			cObject.position = entity.transform.position = target;
		}
	}
}