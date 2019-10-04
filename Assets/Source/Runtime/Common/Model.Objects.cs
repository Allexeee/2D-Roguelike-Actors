using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
		public static void Exit(in ent entity)
		{
			entity.Set(Tag.Exit);
			ref var cCollider = ref entity.Set<ComponentCollider>();

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}
		
		public static void Food(in ent entity)
		{
			ref var cFood = ref entity.Set<ComponentFood>();
			ref var cCollider = ref entity.Set<ComponentCollider>();

			cCollider.collider = entity.GetMono<Collider2D>("collider");

			cFood.count = 5;
		}

	}
}