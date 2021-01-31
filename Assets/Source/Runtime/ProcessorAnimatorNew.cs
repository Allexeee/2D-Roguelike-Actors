//  Project : 2D Roguelike Actors
// Contacts : @Allexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorAnimatorNew : Processor, ITick
	{
		Group<ComponentAnimatorNew> animators;
		
		float time;

		public void Tick(float delta)
		{
			if ((time += delta) < Game.Draw.TimeBetweenFrames) return;
			time -= Game.Draw.TimeBetweenFrames;

			foreach (ent entity in animators)
			{
				var canimator = entity.ComponentAnimatorNew();
				
				var current = canimator.current;
				var next    = canimator.next;
				current.frame    = next.frame;
				current.key      = next.key;
				current.sequence = next.sequence;
      
				if (canimator.animation.OverrideNext(canimator)) goto finish;
				
				next.frame    = current.IsLastFrame() ? 0 : current.frame + 1;
				next.key      = current.key;
				next.sequence = canimator.animation.GetByKey(current.key);
				
				finish:
				canimator.renderer.sprite = current.sequence.sprites[current.frame];
			}
		}
	}
}