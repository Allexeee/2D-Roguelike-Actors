//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using Pixeye.Actors;

namespace Roguelike
{
	public class Tag : ITag
	{
		[TagField]
		public const int None = 0;
		
		// Objects
		[TagField]
		public const int Exit = 100;
		[TagField]
		public const int Wall = 101;
		[TagField]
		public const int Food = 102;
	}
}