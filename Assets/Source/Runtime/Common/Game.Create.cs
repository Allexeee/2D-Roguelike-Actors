//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using System.Collections.Generic;
using Pixeye.Actors;
using TMPro;
using UnityEngine;
using Random = Pixeye.Actors.Random;

namespace Roguelike
{
	public partial class Game
	{
		public static class Create
		{
			static void Player()
			{
				var entity  = LayerGame.Actor.Create(Prefab.Player, new Vector3(1, 1)).entity;
				var     cPlayer = entity.ComponentPlayer();
				var     cHealth = entity.ComponentHealth();

				cPlayer.observer = LayerGame.Observer.Add(cHealth, src => src.count, Callback);

				void Callback(int hp)
				{
					var go = GameObject.Find("UI/Food/Text").GetComponent<TMP_Text>();
					go.text = hp.ToString();
				}
			}

			public static void Board(Layer layer, int columns = 10, int rows = 10)
			{
				List<Vector2> allPos = new List<Vector2>(columns * rows);

				var boardHolder = new GameObject("Board").transform;

				for (int x = 0; x <= columns; x++)
				{
					for (int y = 0; y <= rows; y++)
					{
						if (x == 0 || x == columns || y == 0 || y == rows)
						{
							layer.Obj.Create(Prefab.OuterWalls.Random(), boardHolder, new Vector3(x, y, 0f));
						}
						else
						{
							layer.Obj.Create(Prefab.Floors.Random(), boardHolder, new Vector3(x, y, 0f));

							if (!(x == 1 || x == columns - 1 || y == 1 || y == rows - 1))
								allPos.Add(new Vector2(x, y));
						}
					}
				}

				Create.Player();

				LayerGame.Actor.Create(Prefab.Exit, Models.Exit, new Vector3(rows - 1, columns - 1));

				CreateEntityAtRandom(Prefab.Wall, Models.Wall, ref Database.Walls, 5, 10);

				int enemyCount = (int) Mathf.Log(DataLocal.level, 2f);
				CreateActorAtRandom(Prefab.Enemies, enemyCount, enemyCount);

				CreateEntityAtRandom(Prefab.Food, Models.Food, ref Database.Foods, 2, 5);

				Camera.main.transform.position = new Vector3(rows / 2, columns / 2, -100);

				void CreateEntityAtRandom(GameObject go, ModelComposer model, ref Sprite[] tileArray, int minimum, int maximum)
				{
					int objectCount = Random.Range(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						var entity  = LayerGame.Entity.Create(go, model, randomPosition, true);
						var cObject = entity.ComponentObject();
						cObject.renderer.sprite = tileArray.Random();
					}
				}

				void CreateActorAtRandom(GameObject[] go, int minimum, int maximum)
				{
					int objectCount = Random.Range(minimum, maximum + 1);

					for (int i = 0; i < objectCount; i++)
					{
						var randomPosition = allPos.Random();
						allPos.Remove(randomPosition);

						LayerGame.Actor.Create(go.Random(), randomPosition, true);
					}
				}
			}
		}
	}
}