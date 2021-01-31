﻿using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
 using UnityEngine;

 namespace Pixeye.Source
{
  [Il2CppSetOption(Option.NullChecks, false)]
  [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
  [Il2CppSetOption(Option.DivideByZeroChecks, false)]
  [Serializable]
  public class Seq<T> : IEnumerable
  {
    [SerializeField]
    T[] source = new T[4];
    public int length;

    public ref T this[int index] => ref source[index];

    public ref T Add()
    {
      if (length == source.Length) Array.Resize(ref source, length << 1);
      return ref source[length++];
    }

    public T Add(T val)
    {
      if (length == source.Length) Array.Resize(ref source, length << 1);
      source[length++] = val;
      return val;
    }

    public ref T Get(int index) => ref source[index];

    public ref T Peek()
    {
      return ref source[length - 1];
    }

    public T Get(Predicate<T> predicate)
    {
      for (int i = 0; i < length; i++)
      {
        ref var val = ref source[i];
        if (predicate(val))
          return source[i];
      }

      return default;
    }

    public void RemoveAt(int index)
    {
      if (index < --length)
        Array.Copy(source, index + 1, source, index, length - index);
    }

    public void Remove(Predicate<T> predicate)
    {
      for (int i = 0; i < length; i++)
      {
        ref var val = ref source[i];
        if (predicate(val))
        {
          RemoveAt(i);
          break;
        }
      }
    }

    #region ENUMERATOR

    public Enumerator GetEnumerator()
    {
      return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public struct Enumerator : IEnumerator
    {
      Seq<T> buffer;

      int index;

      // 0 1 2 3 4 5 6
      //   X
      //         Y
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      internal Enumerator(Seq<T> buffer)
      {
        index       = -1;
        this.buffer = buffer;
      }

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public bool MoveNext()
      {
        return ++index < buffer.length;
      }

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void Reset()
      {
        index = -1;
      }

      object IEnumerator.Current => Current;

      public ref T Current
      {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref buffer.source[index];
      }

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void Dispose()
      {
        buffer = null;
      }
    }

    #endregion
  }

  public static class HelperSeq
  {
    public static T Add<T>(this Seq<T> s) where T : new()
    {
      var t = new T();
      s.Add(t);
      return t;
    }
  }
}