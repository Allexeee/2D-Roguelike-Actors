using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Game
	{
		public static void MoveTo(ent entity, Vector2 target)
		{
			ref var cMove = ref entity.AddGet<ComponentMove>();
			cMove.target = target;
		}
	}
}