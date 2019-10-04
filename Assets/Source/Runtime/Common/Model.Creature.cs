using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
		public static void Player(in ent entity)
		{
			entity.Set<ComponentPlayer>();
			entity.Set<ComponentTurnEnd>();

			ref var cObject   = ref entity.Set<ComponentObject>();
			ref var cCollider = ref entity.Set<ComponentCollider>();

			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}

		public static void Enemy(in ent entity)
		{
			entity.Set<ComponentEnemy>();
			
			ref var cObject   = ref entity.Set<ComponentObject>();
			ref var cCollider = ref entity.Set<ComponentCollider>();

			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}
	}
}