using System.Runtime.CompilerServices;
using Pixeye.Actors;

namespace Roguelike
{
	[System.Serializable]
	public class DataEnemy
	{
		public int damage = 1;
	}

	#region HELPERS   

//	static partial class Component
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		internal static DataEnemy DataEnemy(in this ent entity) =>
//			DBHelper.source[entity.id].nodes[Data.Indexer<DataEnemy>.ID] as DataEnemy;
//	}

	#endregion
}