//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Взаимодействие с физикой
///</summary>
public class ProcessorCollisition : Processor
{
    Group<ComponentCollider, ComponentCollision> groupCollisions;

    public ProcessorCollisition()
    {
        groupCollisions.onAdd += AwakeInGroupOfCollisions;
    }

    void AwakeInGroupOfCollisions(in ent entity)
    {
        var cCollisionSource = entity.ComponentCollision();
        // var cColliderSource = entity.ComponentCollider();
        // this.print("Процессор столкновений. Источник " + entity.id);            
        // this.print("Процессор столкновений. Цель: " + cCollisionSource.targetEntity.id + " ");
            // ComponentWall cWall1;
            this.print(cCollisionSource.targetCollider.GetComponentInParent<Actor>().GetEntity().ComponentWall()); //null
            // if (cCollisionSource.targetEntity.Get(out cWall1))

            //     this.print("Wallb:" );

        // Столкновение игрока
        ComponentPlayer cPlayer;
        if (entity.Get(out cPlayer))
        {
            // this.print("Игрок");
            ComponentWall cWall;
            ComponentDamage cDamage;
            ComponentCollider cCollider;
            // со стенкой
            if (cCollisionSource.targetEntity.Get(out cWall))
            {
                // cDamage.Damage += cPlayer.wallDamage;
                this.print("Damage:" );
            }
            // с выходом
            // else if (cCollisionSource.targetEntity.Get(out ))
        }

        entity.Remove<ComponentCollision>();

    }

}