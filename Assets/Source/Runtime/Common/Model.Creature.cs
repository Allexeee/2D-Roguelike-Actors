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

			var cPlayer   = entity.Set<ComponentPlayer>();
			var cObject   = entity.Set<ComponentObject>();
			var cCollider = entity.Set<ComponentCollider>();
			var cHealth   = entity.Set<ComponentHealth>();
			var cAnimator = entity.Set<ComponentAnimator>();
			var cRenderer = entity.Set<ComponentRenderer>();

			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");

			cHealth.count = Game.DataLocal.food;

			cRenderer.source = entity.GetMono<SpriteRenderer>("view");

			cAnimator.map            = Database.Player;
			cAnimator.guide          = AnimatorGuide.Default;
			cAnimator.animation_next = Anim.Idle;
		}

		public static void Enemy(in ent entity)
		{
			entity.Set<ComponentEnemy>();

			var cObject   = entity.Set<ComponentObject>();
			var cCollider = entity.Set<ComponentCollider>();

			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}
	}
}