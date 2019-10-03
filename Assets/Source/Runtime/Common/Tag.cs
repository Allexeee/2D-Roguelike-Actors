//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using Pixeye.Actors;

namespace Pixeye.Source
{
	public class Tag : ITag
	{
		[TagField]
		public const int StateAlive = 0;
		[TagField]
		public const int Hero = 1;
	}
}