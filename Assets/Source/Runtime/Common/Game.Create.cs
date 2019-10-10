using System.Collections.Generic;
using Pixeye.Actors;
using TMPro;
using UnityEngine;

namespace Roguelike
{
	public partial class Game
	{
		public static class Create
		{
			static void Player()
			{
				ref var entity = ref Actor.Create(Prefab.Player, new Vector3(1, 1)).entity;
				var cPlayer = entity.ComponentPlayer();
				var cHealth = entity.ComponentHealth();
				
				var go = GameObject.Find("UI/Food/Text").GetComponent<TMP_Text>();
				cPlayer.observer = cHealth.ValueChange(src => src.count, count => go.text = count.ToString());
			}
			
			public static void Board(int columns = 10, int rows = 10)
			{
				List<Vector2> allPos = new List<Vector2>(columns * rows);

				var boardHolder = new GameObject("Board").transform;

				for (int x = 0; x <= columns; x++)
				{
					for (int y = 0; y <= rows; y++)
					{
						if (x == 0 || x == columns || y == 0 || y == rows)
						{
							Obj.Spawn(Pool.Entities, Prefab.OuterWalls[Random.Range(0, Prefab.OuterWalls.Length)], boardHolder, new Vector3(x, y, 0f));
						}
						else
						{
							Obj.Spawn(Pool.Entities, Prefab.Floors[Random.Range(0, Prefab.Floors.Length)], boardHolder, new Vector3(x, y, 0f));

							if (!(x == 1 || x == columns - 1 || y == 1 || y == rows - 1))
								allPos.Add(new Vector2(x, y));
						}
					}
				}
			
				Create.Player();
				
				Actor.Create(Prefab.Exit, Model.Exit , new Vector3(rows - 1, columns - 1));

				CreateEntityAtRandom(ref Prefab.Walls, 5, 10, Model.Wall);
				int enemyCount = (int)Mathf.Log(DataLocal.level, 2f);
				CreateEntityAtRandom(ref Prefab.Enemies, enemyCount, enemyCount, Model.Enemy);
				CreateEntityAtRandom(ref Prefab.Foods, 2, 5, Model.Food);
				
				Camera.main.transform.position = new Vector3(rows / 2, columns / 2, -100);

				void CreateObjectAtRandom(ref GameObject[] tileArray, int minimum, int maximum)
				{
					int objectCount = Rand.Get(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						Obj.Spawn(tileArray.Random(), randomPosition);
					}
				}

				void CreateEntityAtRandom(ref GameObject[] tileArray, int minimum, int maximum, ModelComposer model)
				{
					int objectCount = Rand.Get(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						Entity.Create(tileArray.Random(), model, randomPosition, true);
					}
				}
			}
		}
	}
}