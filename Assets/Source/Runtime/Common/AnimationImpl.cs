using UnityEngine;

namespace Roguelike
{
  /*
   * Данный класс реализует переходы между анимациями,
   * а также позволит создавать события в анимациях,
   * отслеживать кадры, зацикливать анимацию на определенное кол-во повторений и прочее.
   */
  public abstract class AnimationImpl
  {
    internal readonly AnimationInfo current = new AnimationInfo(); // Актуальная инфа об анимации
    internal readonly AnimationInfo next    = new AnimationInfo(); // Инфа о том, какой спрайт поставить в след. раз
    
    [SerializeField]
    SoAnimation animation;

    public virtual void Bootstrap(AnimKeys key, int frame)
    {
      Play(key, frame);
    }
    
    public void Play(AnimKeys key, int frame)
    {
      next.sequence = animation.GetByKey((int) key);
      next.frame    = Mathf.Clamp(frame, 0, next.sequence.countFrames);
      next.key      = (int) key;
    }

    public Sprite GetNextSprite()
    {
      current.frame    = next.frame;
      current.key      = next.key;
      current.sequence = next.sequence;
      
      if (OverrideNext()) goto finish;
				
      next.frame    = current.IsLastFrame() ? 0 : current.frame + 1;
      next.key      = current.key;
      next.sequence = animation.GetByKey(current.key);
				
      finish:
      return current.sequence.sprites[current.frame];
    }

    protected abstract bool OverrideNext();
  }
}