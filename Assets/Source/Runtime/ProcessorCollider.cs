//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorCollider : Processor<ComponentCollider>
	{
		public override void HandleEvents()
		{
			foreach (ent entity in source.added)
			{
				var cCollider = entity.ComponentCollider();

				Phys.buffer.Insert(entity, cCollider.collider.GetHashCode());
			}

			foreach (ent entity in source.removed)
			{
				var cCollider = entity.ComponentCollider();

				Phys.buffer.Remove(cCollider.collider.GetHashCode());
			}
		}
	}
}