using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
		public static void Exit(in ent entity)
		{
			entity.Set(Tag.Exit);
			var cCollider = entity.Set<ComponentCollider>();

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}

		public static void Food(in ent entity)
		{
			var cHealth   = entity.Set<ComponentHealth>();
			var cCollider = entity.Set<ComponentCollider>();

			cCollider.collider = entity.GetMono<Collider2D>("collider");

			cHealth.count = 5;
		}

		public static void Wall(in ent entity)
		{
			entity.Set(Tag.Wall);

			var cCollider = entity.Set<ComponentCollider>();
			var cHealth   = entity.Set<ComponentHealth>();
			var cRenderer = entity.Set<ComponentRenderer>();

			cCollider.collider = entity.GetMono<Collider2D>("collider");

			cHealth.count = 5;

			cRenderer.source = entity.GetMono<SpriteRenderer>("view");
		}
	}
}