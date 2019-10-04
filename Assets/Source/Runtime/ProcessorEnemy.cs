//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorEnemy : Processor<ComponentObject, ComponentEnemy, ComponentTurnEnd>, ITick
	{
		Group<ComponentObject, ComponentPlayer> groupPlayers;

		Vector2[] direction = new[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right};

		public void Tick(float delta)
		{
			foreach (ent entity in source)
			{
				ref var cObject = ref entity.ComponentObject();

				var dir = direction.Random();
				var target = dir + new Vector2(cObject.position.x, cObject.position.y);

				if (!Phys.HasColliderInPoint(target, 1 << 8, out ent withEntity))
				{
					Game.MoveTo(entity, target);
					entity.Remove<ComponentTurnEnd>();
				}
			}
		}

		public override void HandleEvents()
		{
			foreach (ent entity in source.removed)
			{
				if(source.length==0)
					groupPlayers[0].Add<ComponentTurnEnd>();
			}
		}
	}
}