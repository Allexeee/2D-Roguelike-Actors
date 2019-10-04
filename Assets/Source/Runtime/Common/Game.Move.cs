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