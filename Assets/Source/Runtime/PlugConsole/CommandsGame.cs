using Pixeye.Actors;
using UnityEngine;

namespace Pixeye.Source
{
	[CreateAssetMenu]
	public class CommandsGame : CommandsConsole
	{
		[Bind]
		public void Hello()
		{
			Debug.Log("ACTORS!!!");
		}
	}
}