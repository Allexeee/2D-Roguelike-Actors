using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	// Welcome to the ACTORS.
	// Use Tools->Actors->Update Actors to update version from github if you add Actors from manifest file.
	// Use Tools->Actors->Set Release/Set Debug to toggle between release/debug versions of your project.
	// Press ~ to open the game console. Note that you need to install textmesh pro first.

	public class StarterGame : Starter
	{
		protected override void Setup()
		{
			BoardSetup();

			Toolbox.Add<ProcessorMotion>();
			Toolbox.Add<ProcessorPlayer>();
			Toolbox.Add<ProcessorEnemy>();
		}

		protected override void Dispose()
		{
		}

		void BoardSetup(int columns = 10, int rows = 10)
		{
			var boardHolder = new GameObject("Board").transform;
			for (int x = 0; x < columns + 1; x++)
			{
				for (int y = 0; y < rows + 1; y++)
				{
					if (x == 0 || x == columns || y == 0 || y == rows)
					{
						Obj.Spawn(Pool.Entities, Prefab.OuterWalls[Random.Range(0, Prefab.OuterWalls.Length)], boardHolder, new Vector3(x, y, 0f));
					}
					else
					{
						Obj.Spawn(Pool.Entities, Prefab.Floors[Random.Range(0, Prefab.Floors.Length)], boardHolder, new Vector3(x, y, 0f));
					}
				}
			}
			
			Game.Create.Player(1,1);
//			Game.Create.Player(5,5);
			Game.Create.Enemy(5,5);

			Camera.main.transform.position = new Vector3(rows / 2, columns / 2, -100);
		}
	}
}