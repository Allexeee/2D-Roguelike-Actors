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

			ref var cObject = ref entity.ComponentObject();

			var dir = default(Vector2);

			if (Input.GetKeyDown(KeyCode.UpArrow))
				dir = Vector2.up;
			else if (Input.GetKeyDown(KeyCode.DownArrow))
				dir = Vector2.down;
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
				dir = Vector2.left;
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				dir = Vector2.right;

			if (dir == default) return;
			
			var target = dir + new Vector2(cObject.position.x, cObject.position.y);

			if (!Phys.HasColliderInPoint(target, 1 << 8, out ent withEntity))
			{
				Game.MoveTo(entity, target);
				entity.Remove<ComponentTurnEnd>();
			}
		}

		public override void HandleEvents()
		{
			foreach (ent entity in source.removed)
			{
				Debug.Log($"{source.length}, {groupEnemies.length}");
				if (source.length == 0)
					foreach (ent entityEnemy in groupEnemies)
					{
						entityEnemy.Add<ComponentTurnEnd>();
					}
			}
		}
	}
}