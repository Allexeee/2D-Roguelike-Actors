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
				var cObject = entity.ComponentObject();

				var dir    = direction.Random();
				var target = dir + new Vector2(cObject.position.x, cObject.position.y);

				var hasSolidColliderInPoint = Phys.HasSolidColliderInPoint(target, 1 << 10, out ent withEntity);

				entity.Remove<ComponentTurnEnd>();

				if (!hasSolidColliderInPoint && !withEntity.exist)
				{
					Game.MoveTo(entity, target);
				}
				else if (withEntity.Get(out ComponentPlayer cPlayer))
				{
					ProcessorSignals.Send(new SignalChangeHealth
					{
						target = withEntity,
						count  = -100
					});
				}
			}
		}

		public override void HandleEvents()
		{
			foreach (ent entity in source.removed)
			{
				if (source.length == 0)
					groupPlayers[0].Add<ComponentTurnEnd>();
				break;
			}
		}
	}
}