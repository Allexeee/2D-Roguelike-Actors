//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

// source: https://github.com/dimmpixeye/blog-ru/issues/2

using Pixeye.Actors;

namespace Roguelike
{
	sealed class ProcessorAnimator : Processor, ITick
	{
		Group<ComponentAnimator, ComponentObject> source;
		
		float time;

		public override void HandleEcsEvents()
		{
			foreach (ent entity in source.added)
			{
				var cAnimator = entity.ComponentAnimator();

				if (cAnimator.frame == Anim.RandomFrame)
				{
					ref var sequence = ref cAnimator.map[cAnimator.animation_next];
					cAnimator.frame = Random.Range(0, sequence.sprites.Length);
				}
			}
		}

		public void Tick(float delta)
		{
			// запускаем наш "mecanim"
			foreach (ent entity in source)
			{
				var cAnimator = entity.ComponentAnimator();
				cAnimator.guide.handle(entity, cAnimator, delta);
			}

			// меняем кадры 
			if ((time += delta) < Game.Draw.TimeBetweenFrames) return;
			time -= Game.Draw.TimeBetweenFrames;

			foreach (ent entity in source)
			{
				var cAnimator = entity.ComponentAnimator();
				var cObject   = entity.ComponentObject();

				if (cAnimator.pause) continue;

				ref var sequence = ref cAnimator.map[cAnimator.animation_next];

				if (cAnimator.frame == sequence.sprites.Length)
				{
					if (--cAnimator.times <= 0)
					{
						if (sequence.animation_next != default)
						{
							cAnimator.animation_next = sequence.animation_next;
							sequence                 = ref cAnimator.map[cAnimator.animation_next];
						}
						else cAnimator.overriding = false;
					}

					cAnimator.frame = 0;
				}

				cObject.renderer.sprite = sequence.sprites[cAnimator.frame++];
			}
		}
	}
}