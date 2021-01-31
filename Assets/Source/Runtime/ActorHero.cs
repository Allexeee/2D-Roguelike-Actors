//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using System;
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ActorHero : Actor
	{
		public AnimationHero animationHero;
		ComponentAnimatorNew canimator;
		protected override void Setup()
		{
			canimator = entity.Set<ComponentAnimatorNew>();
			canimator.animationImpl = animationHero;
			canimator.animationImpl.Bootstrap(AnimKeys.Idle, 0); // Этот метод можно вынести куда-нибудь в систему. Но тогда и данные для "старта" тоже придется вынести.
			canimator.renderer = GetComponent<SpriteRenderer>();
			canimator.animationImpl.Play(AnimKeys.Idle, 0);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				canimator.animationImpl.Play(AnimKeys.Idle, 0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				canimator.animationImpl.Play(AnimKeys.Chop, 0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				canimator.animationImpl.Play(AnimKeys.Hit, 0);
			}
		}
	}
}