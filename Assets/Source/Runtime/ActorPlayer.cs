//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
	sealed class ActorPlayer : Actor
	{
		protected override void Setup()
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
	}
}