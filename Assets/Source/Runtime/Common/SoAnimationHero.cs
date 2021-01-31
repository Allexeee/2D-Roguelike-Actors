using System;
using UnityEngine;

namespace Roguelike
{
  [CreateAssetMenu(fileName = "Animation Hero", menuName = "Data/Animation/Hero")]
  [Serializable]
  public class SoAnimationHero : SoAnimation
  {
    public override bool OverrideNext(ComponentAnimatorNew canimator)
    {
      if (ChopFinished(canimator)) return true;
      if (HitFinished(canimator)) return true;
      return false;
    }

    static bool ChopFinished(ComponentAnimatorNew canimator)
    {
      if (canimator.current.key == (int) AnimKeys.Chop && canimator.current.IsLastFrame())
      {
        canimator.Play(AnimKeys.Idle, 0);
        return true;
      }

      return false;
    }

    static bool HitFinished(ComponentAnimatorNew canimator)
    {
      if (canimator.current.key == (int) AnimKeys.Hit && canimator.current.IsLastFrame())
      {
        canimator.Play(AnimKeys.Idle, 0);
        return true;
      }

      return false;
    }
  }
}