//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using System;
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ActorHero : Actor
	{
		public SoAnimationHero animation;

		ComponentAnimatorNew canimator;
		protected override void Setup()
		{
			canimator = entity.Set<ComponentAnimatorNew>();

			canimator.animation = animation;
			canimator.renderer = GetComponent<SpriteRenderer>();
			canimator.Play(AnimKeys.Idle, 0);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				canimator.Play(AnimKeys.Idle, 0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				canimator.Play(AnimKeys.Chop, 0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				canimator.Play(AnimKeys.Hit, 0);
			}
		}
	}
}