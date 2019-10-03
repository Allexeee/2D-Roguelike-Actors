using Pixeye.Actors;

namespace Pixeye.Source
{
	// Welcome to the ACTORS.
	// Use Tools->Actors->Update Actors to update version from github if you add Actors from manifest file.
	// Use Tools->Actors->Set Release/Set Debug to toggle between release/debug versions of your project.
	// Press ~ to open the game console. Note that you need to install textmesh pro first.

	public class StarterGame : Starter
	{
		// use this method to provide processors and initializing stuff.
		protected override void Setup()
		{
		}

		// use thos method to perform "cleanup" before scene dies.
		protected override void Dispose()
		{
			// clear buffer when the scene is removed
		}
	}
}