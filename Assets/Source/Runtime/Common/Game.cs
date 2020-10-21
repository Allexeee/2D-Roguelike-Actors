//  Project : 2D Roguelike Actors
// Contacts : @Alexeee#8796 - https://discord.gg/zAJn9SX

using System.Collections;
using Pixeye.Actors;
using UnityEngine;

namespace Roguelike
{
  public static partial class Game
  {
    public static class DataLocal
    {
      public static int food  = 100;
      public static int level = 0;
    }

    public static void InitComponentObject(this ent entity)
    {
      var cObject = entity.ComponentObject();

      cObject.position = entity.transform.position;
      cObject.collider = entity.GetMono<Collider2D>("collider");
      cObject.renderer = entity.GetMono<SpriteRenderer>("view");
    }

    public static void NextLevel(in ent ePlayer)
    {
      var cHealth = ePlayer.ComponentHealth();

      LayerKernel.Run(CoLoad());

      IEnumerator CoLoad()
      {
        SceneSub.Remove("Scene Game");
        yield return null;
        SceneSub.Add("Scene Game");

        while (LayerKernel.LoadJobs.Count > 0)
        {
          yield return null;
        }
      }

      DataLocal.food = cHealth.count;
      DataLocal.level++;
    }

    public static void ChangeHealth(in ent entity, int count)
    {
      LayerGame.Send(new SignalChangeHealth
      {
        target = entity,
        count  = count
      });
    }
  }

  public static class GameObjectExtension
  {
    public static Object Find(string name, System.Type type)
    {
      Object[] objects = Resources.FindObjectsOfTypeAll(type);
      foreach (var obj in objects)
      {
        if (obj.name == name)
        {
          return obj;
        }
      }

      return null;
    }

    public static GameObject Find(string name)
    {
      return Find(name, typeof(GameObject)) as GameObject;
    }
  }
}