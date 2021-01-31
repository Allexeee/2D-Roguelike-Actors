//  Project : 2D Roguelike Actors
// Contacts : @Allexeee#8796 - https://discord.gg/zAJn9SX

using System;
using Pixeye.Source;
using UnityEngine;

namespace Roguelike
{
	public abstract class SoSequencesNew : ScriptableObject
	{
		Seq<SoSequenceNew> elements = new Seq<SoSequenceNew>();

		public SoSequenceNew this[int index]
		{
			get
			{
#if UNITY_EDITOR
				if (index > elements.length)
				{
					Debug.LogError($"there is no animation with id {index}");
					return default;
				}
#endif
				return elements.Get(index);
			}
		}
	}
}