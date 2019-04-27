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
    Group<ComponentCollider> groupColliders;
    Group<ComponentRigid> groupOfRigids;

    public ProcessorGame()
    {
        groupColliders.onAdd += AwakeInGroupOfColliders;
        groupOfRigids.onAdd += AwakeInGroupOfRigids;
    }

    void AwakeInGroupOfColliders(in ent entity)
    {
        entity.ComponentCollider().source = entity.Get<Collider>();
    }

    void AwakeInGroupOfRigids(in ent entity)
    {
        entity.ComponentRigid().source = entity.Get<Rigidbody2D>();
    }

}