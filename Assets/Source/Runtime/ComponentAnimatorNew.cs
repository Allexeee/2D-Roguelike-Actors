//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

// source: https://github.com/dimmpixeye/blog-ru/issues/2

using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
  public class ComponentAnimatorNew
  {
    public SpriteRenderer renderer;
    public AnimationImpl animationImpl;
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
        component.renderer = default;
        component.animationImpl = default;
      }
    }
  }

  #endregion
}