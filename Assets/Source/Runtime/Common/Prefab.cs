using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	sealed class Prefab
	{
		public static GameObject Player = Box.Get<GameObject>("Prefabs/Obj Player");
		public static GameObject Enemy = Box.Get<GameObject>("Prefabs/Obj Enemy");

		// Level
		public static GameObject Exit = Box.Get<GameObject>("Prefabs/Obj Exit");
		public static GameObject[] Floors = Box.LoadAll<GameObject>("Prefabs/Obj Floor", 8);
		public static GameObject Wall = Box.Get<GameObject>("Prefabs/Obj Wall");
		public static GameObject[] OuterWalls = Box.LoadAll<GameObject>("Prefabs/Obj OuterWall", 3);

		public static GameObject Food =Box.Get<GameObject>("Prefabs/Obj Food");
		
	}
}