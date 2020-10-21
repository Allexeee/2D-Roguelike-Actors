//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using Pixeye.Actors;

namespace Roguelike
{
  public class LayerGame : Layer<LayerGame>
  {
    protected override void Setup()
    {
      Add<ProcessorCollider>();
      Add<ProcessorAnimator>();
      Add<ProcessorHealth>();

      Add<ProcessorPlayer>();
      Add<ProcessorEnemy>();

      WaitFor(0.1f, () => Game.Create.Board(self));
    }
  }
}