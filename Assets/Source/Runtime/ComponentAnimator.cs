//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

// source: https://github.com/dimmpixeye/blog-ru/issues/2
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class ComponentAnimator
	{
		public AnimatorGuide guide = AnimatorGuide.Default; // логика анимаций если нужна

		public Sequences map = new Sequences(); // контейнер анимаций

		public int frame;          // кадр
		public int animation_next; // id анимации
		public int times;          // сколько раз нужно проиграть анимацию

		public float animation_time; // сколько занимает времени анимация

		public bool overriding; // включено ли принудительное проигрывание анимации
		public bool pause;      // стоит ли анимация на паузе
	}
	#region HELPERS

	static partial class Component
	{
		public const string Animator = "Roguelike.ComponentAnimator";

		public static ref ComponentAnimator ComponentAnimator(in this ent entity) =>
			ref Storage<ComponentAnimator>.components[entity.id];
	}

	sealed class StorageComponentAnimator : Storage<ComponentAnimator>
	{
		public override ComponentAnimator Create() => new ComponentAnimator();

		// Use for cleaning components that were removed at the current frame.
		public override void Dispose(indexes disposed)
		{
			foreach (var id in disposed)
			{
				ref var component = ref components[id];
			}
		}
	}

	#endregion
}