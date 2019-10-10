// source: https://github.com/dimmpixeye/blog-ru/issues/2
using System;
using UnityEngine;

namespace Roguelike
{
	public struct Sequence
	{
		public Sprite[] sprites;
		public int animation_next;
		public ref Sprite this[int index] => ref sprites[index];
	}

	public class Sequences
	{
		Sequence[] elements = new Sequence[3];
		int[] keys = new int[3];
		int length;

		public ref Sequence this[int index]
		{
			get
			{
				for (int i = 0; i < length; i++)
				{
					if (keys[i] == index)
						return ref elements[i];
				}

#if UNITY_EDITOR
				Debug.LogError($"there is no animation with id {index}");
#endif

				return ref elements[0];
			}
		}

		public void Add(int key, in Sequence sequence)
		{
			if (elements.Length == length)
			{
				Array.Resize(ref elements, length + 2);
				Array.Resize(ref keys, length + 2);
			}

			keys[length]       = key;
			elements[length++] = sequence;
		}
	}
}