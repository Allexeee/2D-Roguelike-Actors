using System.Collections.Generic;
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
	// Welcome to the ACTORS.
	// Use Tools->Actors->Update Actors to update version from github if you add Actors from manifest file.
	// Use Tools->Actors->Set Release/Set Debug to toggle between release/debug versions of your project.
	// Press ~ to open the game console. Note that you need to install textmesh pro first.

	public class StarterGame : Starter
	{
		protected override void Setup()
		{
			Game.Create.Board();

			Toolbox.Add<ProcessorCollider>();

//			Toolbox.Add<ProcessorMotion>();
			Toolbox.Add<ProcessorPlayer>();
			Toolbox.Add<ProcessorEnemy>();
		}

		protected override void Dispose()
		{
		}


	}
}