using Pixeye.Actors;

namespace Roguelike
{
	sealed class ActorEnemy : Actor
	{
		[FoldoutGroup("Setup", true)]
		[TagFilter(typeof(TypeEnemy))]
		public int type;

		protected override void Setup()
		{
			entity.Set(Database.Units.Enemies[type]);

			entity.Set<ComponentEnemy>();
			entity.Set<ComponentObject>();
			entity.InitComponentObject();

			var cAnimator = entity.Set<ComponentAnimator>();

			cAnimator.map            = Database.Enemies[type];
			cAnimator.guide          = AnimatorGuide.Default;
			cAnimator.animation_next = Anim.Idle;
		}
	}

	public class TypeEnemy : ITag
	{
		[TagField]
		public const int One = 0;

		[TagField]
		public const int Two = 1;
	}
}