// source: https://github.com/dimmpixeye/blog-ru/issues/2
namespace Roguelike
{
	public struct Anim
	{
		public const int RandomFrame = -1;
		public const int Once = 1;
		public const int Loop = int.MaxValue;
		
		public const int None = 0;
		public const int Idle = 1;
		public const int Attack = 2;
		public const int Hit = 3;
	}
}