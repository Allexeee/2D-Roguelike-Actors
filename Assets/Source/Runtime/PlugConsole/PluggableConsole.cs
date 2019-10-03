//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 


#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

using UnityEngine;

namespace Pixeye.Actors
{
	[CreateAssetMenu(menuName = "Actors/Plugables/Console", fileName = "Console")]
	public class PluggableConsole : Pluggable
	{
		[FoldoutGroup("SetupData")]
		public CommandsConsole commandsDebug;

		public override void Plug()
		{
			Toolbox.Add<ProcessorConsole>().Setup(commandsDebug);
		}
	}
}