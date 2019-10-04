using Pixeye.Actors;
using UnityEngine;
using TMPro;

namespace Roguelike
{
	public partial class Model
	{
		public static void Player(in ent entity)
		{
			entity.Set<ComponentTurnEnd>();

			ref var cPlayer = ref entity.Set<ComponentPlayer>();
			ref var cFood = ref entity.Set<ComponentFood>();
			ref var cObject   = ref entity.Set<ComponentObject>();
			ref var cCollider = ref entity.Set<ComponentCollider>();

			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");

			cFood.count = 40;

//			var go = GameObject.Find("UI/Food/Text").GetComponent<TMP_Text>();
//
//			cPlayer.observer = cFood.ValueChange(src => src.count, count => go.text = count.ToString());
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