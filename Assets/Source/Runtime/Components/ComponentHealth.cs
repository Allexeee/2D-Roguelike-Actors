//  Project : 2D-Roguelike-Actors-ProcessorMotion
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentHealth : IComponent
	{

		public int hp;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentHealth>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentHealthInit()
		{
			Storage<ComponentHealth>.Instance.Creator = () => { return new ComponentHealth(); };
		}

		public static ComponentHealth ComponentHealth(in this ent entity)
		{
			return Storage<ComponentHealth>.Instance.components[entity.id];
		}

	}
}