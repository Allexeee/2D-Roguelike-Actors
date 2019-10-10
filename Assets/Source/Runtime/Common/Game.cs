using Pixeye.Actors;

namespace Roguelike
{
	public partial class Game
	{
		public static class DataLocal
		{
			public static int food = 100;
			public static int level = 0;
		}

		public static void NextLevel(in ent ePlayer)
		{
			var cHealth = ePlayer.ComponentHealth();

			ProcessorScene.To("Scene Game");
			DataLocal.food = cHealth.count;
			DataLocal.level++;
		}
	}
}