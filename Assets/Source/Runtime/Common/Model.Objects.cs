//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
	public partial class Models
	{
		public static void Exit(ent entity)
		{
			entity.Set(Tag.Exit);
			
			entity.Set<ComponentObject>();
			entity.InitComponentObject();
		}

		public static void Food(ent entity)
		{
			entity.Set(Tag.Food);
			
			entity.Set<ComponentObject>();
			entity.InitComponentObject();
			
			var cHealth = entity.Set<ComponentHealth>();

			cHealth.count = 5;
		}

		public static void Wall(ent entity)
		{
			entity.Set(Tag.Wall);

			entity.Set<ComponentObject>();
			entity.InitComponentObject();
			
			var cHealth = entity.Set<ComponentHealth>();

			cHealth.count = 5;
		}
	}
}