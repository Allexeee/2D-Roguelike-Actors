//  Project : 2D Roguelike Actors
// Contacts : aleks - ask@pixeye.games

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorPlayer : Processor<ComponentObject, ComponentPlayer, ComponentTurnEnd>, ITick
	{
		Group<ComponentObject, ComponentEnemy> groupEnemies;

		public void Tick(float delta)
		{
			if (source.length == 0) return;
			ref var entity = ref source[0];

			var dir = CheckInput();

			if (dir == default) return;

			var cObject = entity.ComponentObject();
			var cHealth = entity.ComponentHealth();

			var target = dir + new Vector2(cObject.position.x, cObject.position.y);

			if (!Phys.HasSolidColliderInPoint(target, 1 << 10, out ent withEntity))
			{
				Game.MoveTo(entity, target);
				entity.Remove<ComponentTurnEnd>();
				Game.Draw.SetAnimation(entity, Anim.Idle);

				if (withEntity.exist)
				{
					if (withEntity.Has(Tag.Exit))
						Game.NextLevel(entity);
					else if (withEntity.Get(out ComponentHealth cHealth_with))
					{
						cHealth.count += cHealth_with.count;
						withEntity.Release();
					}
				}
				else
					cHealth.count--;
			}
			else
			{
				if (withEntity.Get(out ComponentHealth cHealth_with))
				{
					Game.Draw.SetAnimation(entity, Anim.Attack, Anim.Once);
					ProcessorSignals.Send(new SignalChangeHealth
					{
						target = withEntity,
						count  = -1
					});
				}
			}
		}

		public override void HandleEvents()
		{
			foreach (ent entity in source.removed)
			{
				if (source.length == 0)
					if (groupEnemies.length != 0)
						foreach (ent entityEnemy in groupEnemies)
							entityEnemy.Add<ComponentTurnEnd>();
					else
						entity.Add<ComponentTurnEnd>();

				break;
			}
		}

		Vector2 CheckInput()
		{
			var dir = default(Vector2);

			if (Input.GetKeyDown(KeyCode.UpArrow))
				dir = Vector2.up;
			else if (Input.GetKeyDown(KeyCode.DownArrow))
				dir = Vector2.down;
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
				dir = Vector2.left;
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				dir = Vector2.right;
			return dir;
		}
	}
}