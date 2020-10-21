//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using System.Runtime.CompilerServices;
using Pixeye.Actors;

namespace Roguelike
{
  public partial class Database
  {
    public class Units
    {
      public static DataEnemy[] Enemies;

      public static void Load()
      {
        Enemies = new DataEnemy[2];
        LoadEnemy0();
        LoadEnemy2();
      }

      static void LoadEnemy0()
      {
        var dEnemy = Enemies[0] = new DataEnemy();
        dEnemy.damage = 1;
      }

      static void LoadEnemy2()
      {
        var dEnemy = Enemies[1] = new DataEnemy();
        dEnemy.damage = 10;
      }
    }
  }

  public static partial class HelperGame
  {
    public static DataEnemy[] Dataset = new DataEnemy[LayerKernel.Settings.SizeEntities];

    public static void Bind(this ent entity, DataEnemy dataEnemy)
    {
      Dataset[entity.id] = dataEnemy;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DataEnemy DataEnemy(in this ent entity) => Dataset[entity.id];
  }
}