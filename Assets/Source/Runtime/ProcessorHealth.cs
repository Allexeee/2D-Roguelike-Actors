//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using TMPro;
using UnityEngine;

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

			else if (entity.Has(Tag.Food))
			{
				entity.Release();
			}

			else if (entity.Has<ComponentPlayer>())
			{
				if (health <= 0)
				{
					cHealth.count = 0;
					entity.Remove<ComponentPlayer>();

					var goText = GameObject.Find("UI").transform.GetChild(1);
					goText.GetChild(1).GetComponent<TMP_Text>().text = $"Days: {Game.DataLocal.level}";
					goText.gameObject.SetActive(true);
				}
			}
		}
	}
}