using System;
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
  [CreateAssetMenu(fileName = "Sequence Item", menuName = "Data/Sequence")]
  [Serializable]
  public class SoSequenceNew : ScriptableObject
  {
    public Sprite[] sprites;
    public Sprite this[int index] => sprites[index];

    public int countFrames => sprites.Length - 1;
  }
}