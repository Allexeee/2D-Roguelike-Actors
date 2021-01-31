using System;

namespace Roguelike
{
  [Serializable]
  public class AnimationHero : AnimationImpl
  {
    protected override bool OverrideNext()
    {
      if (ChopFinished()) return true;
      if (HitFinished()) return true;
      return false;
    }

    bool ChopFinished()
    {
      if (current.key == (int) AnimKeys.Chop && current.IsLastFrame())
      {
        Play(AnimKeys.Idle, 0);
        return true;
      }

      return false;
    }

    bool HitFinished()
    {
      if (current.key == (int) AnimKeys.Hit && current.IsLastFrame())
      {
        Play(AnimKeys.Idle, 0);
        return true;
      }

      return false;
    }
  }
}