//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

// source: https://github.com/dimmpixeye/blog-ru/issues/2

using Pixeye.Actors;

namespace Roguelike
{
	public partial class Game
	{
		public static class Draw
		{
			public const float TimeBetweenFrames = 0.064f; //0.064f;

			public static float SetAnimation(in ent entity, int animation_id, int times = Anim.Loop, int frame = 0)
			{
				var cAnimator = entity.ComponentAnimator();
				var cObject   = entity.ComponentObject();

				cAnimator.times = times;

				if (cAnimator.animation_next == animation_id) return cAnimator.animation_time;

				ref var sequence = ref cAnimator.map[animation_id];

				cAnimator.frame          = frame == Anim.RandomFrame ? Random.Range(0, sequence.sprites.Length) : frame;
				cObject.renderer.sprite  = sequence[cAnimator.frame];
				cAnimator.animation_next = animation_id;
				cAnimator.overriding     = true;
				cAnimator.animation_time = times * sequence.sprites.Length * TimeBetweenFrames - cAnimator.frame * TimeBetweenFrames;
				return cAnimator.animation_time;
			}
			
			public static void ResetAnimation(in ent entity)
			{
				var cAnimator = entity.ComponentAnimator();

				if (!cAnimator.overriding) return;

				cAnimator.overriding = false;
				cAnimator.frame      = 0;
				cAnimator.times      = 1;
			}
		}
	}
}