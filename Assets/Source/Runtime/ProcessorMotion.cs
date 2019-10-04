//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorMotion : Processor
	{
		Group<ComponentObject, ComponentMove> groupMotion;

		public override void HandleEvents()
		{
			foreach (ent entity in groupMotion.added)
			{
				ref var cObject = ref entity.ComponentObject();
				ref var cMove = ref entity.ComponentMove();

				cObject.position = entity.transform.position = cMove.target;

				entity.Remove<ComponentMove>();
			}
		}
	}
}