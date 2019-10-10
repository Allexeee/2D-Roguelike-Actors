// source: https://github.com/dimmpixeye/blog-ru/issues/2
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	public class Database
	{
		//===============================//
		// Спрайты
		//===============================//

		public static Sprite[] RuinedWall;
		
		//===============================//
		// Анимации
		//===============================//

		public static Sequences Player;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void Setup()
		{
			var sequences = default(Sequences);
			var atlas     = Box.LoadAll<Sprite>("Sprites/Scavengers_SpriteSheet");

			//===============================//
			// LOAD
			//===============================//

			RuinedWall = atlas.Slice("RuinedWall_0", 7);
			
			LoadPlayer();

			//===============================//
			// Methods
			//===============================//

			void LoadPlayer()
			{
				sequences = Player = new Sequences();

				sequences.Add(Anim.Idle, new Sequence
				{
					sprites = atlas.Slice(src => src.name.Equals("Player_Idle_0"),6,1),
				});

				sequences.Add(Anim.Attack, new Sequence
				{
					sprites = atlas.Slice(src => src.name.Equals("Player_Chop_0"),2,1),
					animation_next = Anim.Idle
				});
			}
		}
	}
}