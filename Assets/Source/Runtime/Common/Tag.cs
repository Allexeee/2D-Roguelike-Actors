//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using Pixeye.Actors;

namespace Roguelike
{
	public class Tag : ITag
	{
		[TagField]
		public const int None = 0;
		[TagField]
		public const int Player = 1;
	}
}