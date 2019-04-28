//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
/// Взаимодействия с миром.
/// eSource - источник действия
/// eTarget - цель, к которой применяется действие
///</summary>

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
        ///<summary>
        /// Нанесение урона стене
        ///</summary>
        public class Damage : CollisionBase
        {
            public override void Interact(in ent eSource, in ent eTarget, bool isTrigger = false)
            {
                ComponentHealth cHealth;
                // Если цель имеет здоровье
                if (eTarget.Get(out cHealth))
                {
                    cHealth.ActionHealthChanged.Interact(eSource, eTarget);
                }
            }
        }
    }

    public class General
    {
        ///<summary>
        /// Разрушение стены (уменьшение хп + уничтожение стены)
        ///</summary>
        public class WallsCollapsing : GeneralBase
        {
            public override void Interact(in ent eSource, in ent eTarget)
            {
                // Необходимо узнать, может ли источник нанести урон стене
                int dmg = 0;
                ComponentDamageWall cDamageWall;
                if (!eSource.Get(out cDamageWall)) 
                    return;

                dmg = cDamageWall.wallDamage;
                ref var hp = ref eTarget.ComponentHealth().Health;
                hp -= dmg;

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
    public static Interactables.Collision.Damage Damage = new Interactables.Collision.Damage();

    public static Interactables.General.WallsCollapsing WallsCollapsing = new Interactables.General.WallsCollapsing();
}