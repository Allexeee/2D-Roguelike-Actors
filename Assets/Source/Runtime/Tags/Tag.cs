//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;

namespace Pixeye
{
	public class Tag : ITag
	{

		[TagField]
		public const int None = 0;

		[TagField] public const int Wall = 1;
		[TagField] public const int Player = 2;
		[TagField] public const int Enemy = 3;
		[TagField] public const int CanMotion = 4;
	}
}