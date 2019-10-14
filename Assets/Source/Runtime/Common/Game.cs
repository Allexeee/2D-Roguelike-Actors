using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public static partial class Game
	{
		public static class DataLocal
		{
			public static int food = 100;
			public static int level = 0;
		}

		public static void InitComponentObject(this ent entity)
		{
			var cObject = entity.ComponentObject();
			
			cObject.position = entity.transform.position;
			cObject.collider = entity.GetMono<Collider2D>("collider");
			cObject.renderer = entity.GetMono<SpriteRenderer>("view");
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