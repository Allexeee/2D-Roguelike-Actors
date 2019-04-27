//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public class Interactables
{
    public abstract class GeneralBase
    {
        public abstract void Interact(in ent eSource, in ent eTarget);
    }

    public abstract class CollisionBase
    {
        public abstract void Interact(in ent eSource, in ent eTarget, bool isTrigger = false);
    }

    public class Collision
    {
        public class DamageWall : CollisionBase
        {
            public override void Interact(in ent eSource, in ent eTarget, bool isTrigger = false)
            {
                var cDamageWall = eSource.ComponentPlayer();
                ComponentHealth cHealth;
                // Если цель имеет здоровье
                if (eTarget.Get(out cHealth))
                {
                    // Если это стена. По идее, в игре здоровье есть только у стен, поэтому эту проверку можно опустить,
                    // но если мы добавим что-то еще со здоровьем, то это вызовет ошибку
                    if (eTarget.Has(Tag.Wall))
                    {
                        this.print("DamageWall");
                        cHealth.Health -= cDamageWall.wallDamage;
                        cHealth.ActionHealthChanged.Interact(eSource, eTarget);
                    }
                }
            }
        }
    }

    public class General
    {
        public class DestructionWalls : GeneralBase
        {
            public override void Interact(in ent eSource, in ent eTarget)
            {
                ref var hp = ref eTarget.ComponentHealth().Health;
                this.print($"Здоровье изменилось. Стало: {hp}");
                if (hp <= 0)
                {
                    eTarget.Release();
                }
            }
        }
    }
}

public static class Scriptables
{
    public static Interactables.Collision.DamageWall DamageWall = new Interactables.Collision.DamageWall();

    public static Interactables.General.DestructionWalls DestructionWalls = new Interactables.General.DestructionWalls();
}