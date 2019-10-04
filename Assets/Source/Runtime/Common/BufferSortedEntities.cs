using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;

namespace Pixeye.Source
{
	[Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks | Option.DivideByZeroChecks, false)]
	public sealed class BufferSortedEntities
	{
		public int[] pointers = new int[50000];
		public ent[] entities = new ent[50000];

		public int length;

		public BufferSortedEntities(int size)
		{
			pointers = new int[size];
			entities = new ent[size];
		}

		//===============================//
		// Insert
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Insert(in ent entity, int instanceID)
		{
			var left  = 0;
			var index = 0;
			var right = length++;

			if (length >= pointers.Length)
			{
				var l = left << 1;
				Array.Resize(ref entities, l);
				Array.Resize(ref pointers, l);
			}

			var consitionSort = right - 1;
			if (consitionSort > -1 && instanceID < pointers[consitionSort])
			{
				while (right > left)
				{
					var midIndex = (right + left) / 2;

					if (pointers[midIndex] == instanceID)
					{
						index = midIndex;
						break;
					}

					if (pointers[midIndex] < instanceID)
						left = midIndex + 1;
					else
						right = midIndex;

					index = left;
				}

				Array.Copy(pointers, index, pointers, index + 1, length - index);
				Array.Copy(entities, index, entities, index + 1, length - index);
				entities[index] = entity;
				pointers[index] = instanceID;
			}
			else
			{
				pointers[right] = instanceID;
				entities[right] = entity;
			}
		}


		//===============================//
		// GET
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int instanceID, out ent entity)
		{
			var left  = 0;
			var right = length;

			while (left <= right)
			{
				var m = (left + right) / 2;
				if (pointers[m] == instanceID)
				{
					entity = entities[m];
					return true;
				}

				if (pointers[m] < instanceID) left = m + 1;
				else right                         = m - 1;
			}


			entity = default;
			return false;
		}

		//===============================//
		// REMOVE
		//===============================//
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Remove(int instanceID)
		{
			if (length == 0) return;
			var i = HelperArray.BinarySearch(ref pointers, instanceID, 0, length);
			if (i == -1) return;
			Array.Copy(pointers, i + 1, pointers, i, length - i);
			Array.Copy(entities, i + 1, entities, i, length-- - i);
		}
	}
}