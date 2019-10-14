//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorCollider : Processor<ComponentObject>
	{
		public override void HandleEvents()
		{
			foreach (ent entity in source.added)
			{
				var cObject = entity.ComponentObject();
				
				Phys.buffer.Insert(entity, cObject.collider.GetHashCode());
			}

			foreach (ent entity in source.removed)
			{
				var cObject = entity.ComponentObject();

				Phys.buffer.Remove(cObject.collider.GetHashCode());
			}
		}
	}
}