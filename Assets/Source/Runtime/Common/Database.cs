// source: https://github.com/dimmpixeye/blog-ru/issues/2

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public partial class Database
	{
		//===============================//
		// Спрайты
		//===============================//

		public static Sprite[] RuinedWalls;
		public static Sprite[] Walls;
		public static Sprite[] Foods;

		//===============================//
		// Анимации
		//===============================//

		public static Sequences Player;
		public static Sequences[] Enemies;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void Setup()
		{
			var sequences = default(Sequences);
			var atlas     = Box.LoadAll<Sprite>("Sprites/Scavengers_SpriteSheet");

			//===============================//
			// LOAD
			//===============================//

			RuinedWalls = atlas.Slice("RuinedWall_0", 7);
			Walls       = atlas.Slice("Wall_0", 8);
			Foods       = atlas.Slice("Food_0", 2);

			Units.Load();

			LoadPlayer();
			Enemies = new Sequences[2];
			LoadEnemy0();
			LoadEnemy1();

			//===============================//
			// Methods
			//===============================//

			void LoadPlayer()
			{
				sequences = Player = new Sequences();

				sequences.Add(Anim.Idle, new Sequence
				{
					sprites = atlas.Slice(src => src.name.Equals("Player_Idle_0"), 6, 3),
				});

				sequences.Add(Anim.Attack, new Sequence
				{
					sprites        = atlas.Slice(src => src.name.Equals("Player_Chop_0"), 2, 2),
					animation_next = Anim.Idle
				});
				
				sequences.Add(Anim.Hit, new Sequence
				{
					sprites        = atlas.Slice(src => src.name.Equals("Player_Hit_0"), 2, 2),
					animation_next = Anim.Idle
				});
			}

			void LoadEnemy0()
			{
				sequences = Enemies[0] = new Sequences();

				sequences.Add(Anim.Idle, new Sequence
				{
					sprites = atlas.Slice(src => src.name.Equals("Enemy1_Idle_0"), 6, 3),
				});

				sequences.Add(Anim.Attack, new Sequence
				{
					sprites        = atlas.Slice(src => src.name.Equals("Enemy1_Attack_0"), 2, 2),
					animation_next = Anim.Idle
				});
			}

			void LoadEnemy1()
			{
				sequences = Enemies[1] = new Sequences();

				sequences.Add(Anim.Idle, new Sequence
				{
					sprites = atlas.Slice(src => src.name.Equals("Enemy2_Idle_0"), 6, 3),
				});

				sequences.Add(Anim.Attack, new Sequence
				{
					sprites        = atlas.Slice(src => src.name.Equals("Enemy2_Attack_0"), 2, 2),
					animation_next = Anim.Idle
				});
			}
		}
	}
}