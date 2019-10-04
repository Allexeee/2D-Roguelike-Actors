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
				ref var cCollider = ref entity.ComponentCollider();
				
				Phys.buffer.Insert(entity, cCollider.collider.GetHashCode());
			}

			foreach (ent entity in source.removed)
			{
				ref var cCollider = ref entity.ComponentCollider();

				Phys.buffer.Remove(cCollider.collider.GetHashCode());
			}
		}
	}
}