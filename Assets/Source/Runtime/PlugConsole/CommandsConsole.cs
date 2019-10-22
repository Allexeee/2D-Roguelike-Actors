//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 


using UnityEngine;

namespace Pixeye.Actors
{
	public abstract class CommandsConsole : ScriptableObject
	{
		public ent lastEntity;

		[Bind]
		public string Help()
		{
			return Toolbox.Get<ProcessorConsole>().Help();
		}

		[Bind]
		public string Create(string prefabID, Vector3 position)
		{
			var e = Actor.Create(prefabID, position).entity;
			return $"Entity {e.transform.name} with ID [{e.id}] was created!";
		}

		[Bind]
		public string Get(int id)
		{
			lastEntity = id;
			return $"Entity with ID [{id}] recieved ";
		}
	}
}