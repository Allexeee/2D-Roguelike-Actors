using System;
using UnityEngine;

namespace Roguelike
{
  /*
   * Последовательность кадров
   */
  [CreateAssetMenu(fileName = "Sequence Item", menuName = "Data/Sequence")]
  [Serializable]
  public class SoSequenceNew : ScriptableObject
  {
    public Sprite[] sprites;
    public int countFrames => sprites.Length - 1;
  }
}