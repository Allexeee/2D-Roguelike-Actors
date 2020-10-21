//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
	sealed class ProcessorCollider : Processor
	{
		Group<ComponentObject> source;
		
		public override void HandleEcsEvents()
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