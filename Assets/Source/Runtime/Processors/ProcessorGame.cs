//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Процессор-инициализатор (запихивает в компоненты ссылки на юнити-компоненты)
///</summary>
public class ProcessorGame : Processor
{
    Group<ComponentCollider> groupOfColliders;
    Group<ComponentRigid> groupOfRigids;
    Group<ComponentAnim> groupOfAnim;

    public ProcessorGame()
    {
        groupOfColliders.onAdd += AwakeInGroupOfColliders;
        groupOfRigids.onAdd += AwakeInGroupOfRigids;
        groupOfAnim.onAdd += AwakeInGroupOfAnim;
    }

    void AwakeInGroupOfColliders(in ent entity)
    {
        entity.ComponentCollider().source = entity.Get<Collider2D>("collider");
    }

    void AwakeInGroupOfRigids(in ent entity)
    {
        entity.ComponentRigid().source = entity.Get<Rigidbody2D>();
    }

    void AwakeInGroupOfAnim(in ent entity)
    {
			var animator = entity.Get<Animator>("view");
			animator.runtimeAnimatorController = entity.ComponentAnim().source;
    }
}