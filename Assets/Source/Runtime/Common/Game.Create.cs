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
				ref var entity  = ref Actor.Create(Prefab.Player, new Vector3(1, 1)).entity;
				var     cPlayer = entity.ComponentPlayer();
				var     cHealth = entity.ComponentHealth();

				cPlayer.observer = cHealth.ValueChange(src => src.count, Callback);

				void Callback(int hp)
				{
					var go = GameObject.Find("UI/Food/Text").GetComponent<TMP_Text>();
					go.text = hp.ToString();
				}
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

				Actor.Create(Prefab.Exit, Model.Exit, new Vector3(rows - 1, columns - 1));

				CreateEntityAtRandom(Prefab.Wall, Model.Wall, ref Database.Walls, 5, 10);

				int enemyCount = (int) Mathf.Log(DataLocal.level, 2f);
//				CreateEntityAtRandom1(ref Model.Enemies, enemyCount, enemyCount);
				CreateEntityAtRandom2(Prefab.Enemies, enemyCount, enemyCount);

				CreateEntityAtRandom(Prefab.Food, Model.Food, ref Database.Foods, 2, 5);

				Camera.main.transform.position = new Vector3(rows / 2, columns / 2, -100);

				void CreateEntityAtRandom(GameObject go, ModelComposer model, ref Sprite[] tileArray, int minimum, int maximum)
				{
					int objectCount = Rand.Get(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						var entity  = Entity.Create(go, model, randomPosition, true);
						var cObject = entity.ComponentObject();
						cObject.renderer.sprite = tileArray.Random();
					}
				}

				void CreateEntityAtRandom2(GameObject[] go, int minimum, int maximum)
				{
					int objectCount = Rand.Get(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						var entity = Actor.Create(go.Random(), randomPosition, true).entity;
					}
				}

				void CreateEntityAtRandom1(ref ModelComposer[] tileArray, int minimum, int maximum)
				{
					int objectCount = Rand.Get(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						Entity.Create(Prefab.Enemy, tileArray.Random(), randomPosition, true);
					}
				}
			}
		}
	}
}