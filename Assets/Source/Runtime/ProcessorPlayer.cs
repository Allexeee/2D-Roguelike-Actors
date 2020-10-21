//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class ProcessorPlayer : Processor, ITick
	{
		Group<ComponentObject, ComponentPlayer, ComponentTurnEnd> source;
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

			var hasSolidColliderInPoint = Phys.HasSolidColliderInPoint(target, 1 << 10, out ent withEntity);

			if (hasSolidColliderInPoint && (!withEntity.exist || withEntity.Has<ComponentEnemy>())) return;

			if (!hasSolidColliderInPoint)
			{
				Game.MoveTo(entity, target);
			
				// Встали на некий триггер
				if (withEntity.exist)
				{
					// Выход
					if (withEntity.Has(Tag.Exit))
						Game.NextLevel(entity);
					// Еда
					else if (withEntity.TryGet(out ComponentHealth cHealth_with))
					{
						Game.ChangeHealth(entity, cHealth_with.count);
						Game.ChangeHealth(withEntity, -cHealth_with.count);
					}
				}
			}
			// Стена
			else
			{
				Game.Draw.SetAnimation(entity, Anim.Attack, Anim.Once);
				Game.ChangeHealth(withEntity, -1);
			}
			
			Game.ChangeHealth(entity, -1);
			entity.Remove<ComponentTurnEnd>();
		}

		public override void HandleEcsEvents()
		{
			foreach (ent entity in source.removed)
			{
				if (source.length == 0)
					if (groupEnemies.length != 0)
						foreach (ent entityEnemy in groupEnemies)
							entityEnemy.Get<ComponentTurnEnd>();
					else
						entity.Get<ComponentTurnEnd>();

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