// source: https://github.com/dimmpixeye/blog-ru/issues/2
using Pixeye.Actors;

namespace Roguelike
{
	public abstract class AnimatorGuide
	{
		public static AnimatorGuide Default = new AnimatorGuideDefault();
		public abstract void handle(ent entity, ComponentAnimator cAnimator, float delta);
	}

	public abstract class AnimatorGuide<T> : AnimatorGuide where T : new()
	{
		public static T Instance = new T();
	}

	sealed class AnimatorGuideDefault : AnimatorGuide
	{
		public override void handle(ent entity, ComponentAnimator cAnimator, float delta)
		{
		}
	}
}