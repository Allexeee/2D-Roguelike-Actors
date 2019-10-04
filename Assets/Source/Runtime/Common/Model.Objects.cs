using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Model
	{
		public static void Exit(in ent entity)
		{
//			ref var cObject = ref entity.Set<ComponentObject>();

			entity.Set(Tag.Exit);
			ref var cCollider = ref entity.Set<ComponentCollider>();

//			cObject.position = entity.transform.position;

			cCollider.collider = entity.GetMono<Collider2D>("collider");
		}
	}
}