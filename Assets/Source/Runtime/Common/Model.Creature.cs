using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
//		public static ModelComposer[] Enemies = new[] {(ModelComposer) Enemy1, (ModelComposer) Enemy2};
		
		public static void Player(in ent entity)
		{
			entity.Set<ComponentTurnEnd>();

			var cPlayer   = entity.Set<ComponentPlayer>();
			var cObject   = entity.Set<ComponentObject>();
			var cHealth   = entity.Set<ComponentHealth>();
			var cAnimator = entity.Set<ComponentAnimator>();
			
			entity.InitComponentObject();
			
			cHealth.count = Game.DataLocal.food;

			cAnimator.map            = Database.Player;
			cAnimator.guide          = AnimatorGuide.Default;
			cAnimator.animation_next = Anim.Idle;
		}

//		public static void Enemy1(in ent entity)
//		{
//			entity.Set<ComponentEnemy>();
//
//			var cObject   = entity.Set<ComponentObject>();
//			var cAnimator = entity.Set<ComponentAnimator>();
//			
//			entity.InitComponentObject();
//
//			cAnimator.map            = Database.Enemy1;
//			cAnimator.guide          = AnimatorGuide.Default;
//			cAnimator.animation_next = Anim.Idle;
//		}
//
//		public static void Enemy2(in ent entity)
//		{
//			entity.Set<ComponentEnemy>();
//
//			var cObject   = entity.Set<ComponentObject>();
//			var cAnimator = entity.Set<ComponentAnimator>();
//			
//			entity.InitComponentObject();
//
//			cAnimator.map            = Database.Enemy2;
//			cAnimator.guide          = AnimatorGuide.Default;
//			cAnimator.animation_next = Anim.Idle;
//		}
	}
}