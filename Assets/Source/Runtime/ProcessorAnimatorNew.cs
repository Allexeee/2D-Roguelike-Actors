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

				canimator.renderer.sprite = canimator.animationImpl.GetNextSprite();
			}
		}
	}
}