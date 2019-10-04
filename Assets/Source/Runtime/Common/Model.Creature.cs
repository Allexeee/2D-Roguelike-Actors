using Pixeye.Actors;

namespace Roguelike
{
	public partial class Model
	{
		public static void Player(in ent entity)
		{
			entity.Set<ComponentObject>().position = entity.transform.position;
			entity.Set<ComponentPlayer>();
			entity.Set<ComponentTurnEnd>();
		}
		
		public static void Enemy(in ent entity)
		{
			entity.Set<ComponentObject>().position = entity.transform.position;
			entity.Set<ComponentEnemy>();
		}

	}
}