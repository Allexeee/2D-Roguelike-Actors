//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;

namespace Roguelike
{
	sealed class ProcessorHealth : Processor, IReceive<SignalChangeHealth>
	{
		public void HandleSignal(in SignalChangeHealth arg)
		{
			var entity  = arg.target;
			var cHealth = entity.ComponentHealth();
			var cObject = entity.ComponentObject();

			var health = cHealth.count += arg.count;

			if (entity.Has(Tag.Wall))
			{
				cObject.renderer.sprite = Database.RuinedWalls.RandomExcept(cObject.renderer.sprite);
				if (health <= 0)
					entity.Release();
			}
		}
	}
}