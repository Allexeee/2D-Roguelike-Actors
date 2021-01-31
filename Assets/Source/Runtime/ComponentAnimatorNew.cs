//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

// source: https://github.com/dimmpixeye/blog-ru/issues/2

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
  public class ComponentAnimatorNew
  {
    /*
     * Спрайты меняются не каждый кадр, из-за чего перед установкой след. анимации может пройти несколько кадров.
     * Но все спрайты меняются в один такт времени, т.е синхронно
    */
    public readonly AnimationInfo current = new AnimationInfo(); // Актуальная инфа об анимации
    public readonly AnimationInfo next    = new AnimationInfo(); // Инфа о том, какой спрайт поставить в след. раз

    public SpriteRenderer renderer;
    public SoAnimation animation;
    
    public void Play(AnimKeys key, int frame)
    {
      next.sequence = animation.GetByKey((int) key);
      next.frame    = Mathf.Clamp(frame, 0, next.sequence.countFrames);
      next.key      = (int) key;
    }
  }

  public class AnimationInfo
  {
    public int key;
    public int frame;
    public SoSequenceNew sequence;

    public bool IsLastFrame()
    {
      return frame == sequence.sprites.Length - 1;
    }
    
    public void Dispose()
    {
      key   = default;
      frame = default;
    }
  }

  #region HELPERS

  static partial class Component
  {
    public const string AnimatorNew = "Roguelike.ComponentAnimatorNew";

    public static ref ComponentAnimatorNew ComponentAnimatorNew(in this ent entity) =>
      ref Storage<ComponentAnimatorNew>.components[entity.id];
  }

  sealed class StorageComponentAnimatorNew : Storage<ComponentAnimatorNew>
  {
    public override ComponentAnimatorNew Create() => new ComponentAnimatorNew();

    // Use for cleaning components that were removed at the current frame.
    public override void Dispose(indexes disposed)
    {
      foreach (var id in disposed)
      {
        ref var component = ref components[id];
        component.current.Dispose();
        component.next.Dispose();
        component.renderer = default;
      }
    }
  }

  #endregion
}