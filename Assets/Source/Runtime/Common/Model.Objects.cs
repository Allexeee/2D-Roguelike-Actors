using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
		public static void Exit(in ent entity)
		{
			entity.Set(Tag.Exit);
			var cObject = entity.Set<ComponentObject>();
			
			entity.InitComponentObject();

		}

		public static void Food(in ent entity)
		{
			var cHealth = entity.Set<ComponentHealth>();
			var cObject = entity.Set<ComponentObject>();
			
			entity.InitComponentObject();


			cHealth.count = 5;
		}

		public static void Wall(in ent entity)
		{
			entity.Set(Tag.Wall);

			var cHealth = entity.Set<ComponentHealth>();

			var cObject = entity.Set<ComponentObject>();
			
			entity.InitComponentObject();


			cHealth.count = 5;
		}
	}
}