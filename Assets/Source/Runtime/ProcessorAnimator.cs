// source: https://github.com/dimmpixeye/blog-ru/issues/2
using Pixeye.Actors;

namespace Roguelike
{
	sealed class ProcessorAnimator : Processor<ComponentAnimator, ComponentRenderer>, ITick
	{
		float time;

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
				var cRenderer = entity.ComponentRenderer();

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


				cRenderer.source.sprite = sequence.sprites[cAnimator.frame++];
			}
		}
	}
}