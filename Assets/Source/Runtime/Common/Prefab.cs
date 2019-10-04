using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class Prefab
	{
		public static GameObject Player = Box.Get<GameObject>("Prefabs/Obj Player");
		public static GameObject[] Enemies = Box.LoadAll<GameObject>("Prefabs/Obj Enemy", 2);

		// Level
		public static GameObject Exit = Box.Get<GameObject>("Prefabs/Obj Exit");
		public static GameObject[] Floors = Box.LoadAll<GameObject>("Prefabs/Obj Floor", 8);
		public static GameObject[] Walls = Box.LoadAll<GameObject>("Prefabs/Obj Wall", 8);
		public static GameObject[] OuterWalls = Box.LoadAll<GameObject>("Prefabs/Obj OuterWall", 3);

		public static GameObject[] Foods = new[]
		{
			Box.Get<GameObject>("Prefabs/Obj Food"),
			Box.Get<GameObject>("Prefabs/Obj Soda"),
		};

	}
}