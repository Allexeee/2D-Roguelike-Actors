using Pixeye.Actors;

namespace Roguelike
{
	public partial class Database
	{
		public class Units
		{
			public static Data[] Enemies;

			public static void Load()
			{
				Enemies = new Data[2];
				LoadEnemy0();
				LoadEnemy2();
			}

			static void LoadEnemy0()
			{
				var data = Enemies[0] = new Data();

				var dEnemy = data.Add<DataEnemy>();
				dEnemy.damage = 1;
			}

			static void LoadEnemy2()
			{
				var data = Enemies[1] = new Data();

				var dEnemy = data.Add<DataEnemy>();
				dEnemy.damage = 10;
			}
		}
	}
}