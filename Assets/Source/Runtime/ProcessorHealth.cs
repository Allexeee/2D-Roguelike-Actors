//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorHealth : Processor, IReceive<SignalChangeHealth>
	{
		public void HandleSignal(in SignalChangeHealth arg)
		{
			var entity    = arg.target;
			var cHealth   = entity.ComponentHealth();
			var cRenderer = entity.ComponentRenderer();

			var health = cHealth.count += arg.count;

			if (entity.Has(Tag.Wall))
			{
				cRenderer.source.sprite = Database.RuinedWall.Random();
				if (health <= 0)
					entity.Release();
			}
		}
	}
}