using System;
using UnityEngine;

namespace Roguelike
{
  /*
   * Данный класс предназначен для хранения последовательностей кадров и ключей
   */
  [CreateAssetMenu(fileName = "Animation Default", menuName = "Data/Animation/Default")]
  [Serializable]
  public class SoAnimation : ScriptableObject
  {
    [SerializeField]
    SoSequenceNew[] elements;

    [SerializeField]
    AnimKeys[] keys;

    int GetIndexByKey(int key)
    {
      for (int i = 0; i < keys.Length; i++)
        if (key == (int) keys[i])
          return i;

      Debug.LogError($"there is no animation with id {key}");
      return 0;
    }

    public SoSequenceNew GetByKey(int key)
    {
      return elements[GetIndexByKey(key)];
    }
  }
}