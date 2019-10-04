using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Game
	{
		public static class Create
		{
			public static void Player(int x, int y)
			{
				Actor.Create(Prefab.Player, new Vector3(x, y));
			}
			
			public static void Enemy(int x, int y)
			{
				Actor.Create(Prefab.Enemies[0], Model.Enemy , new Vector3(x, y));
			}
		}
	}
}