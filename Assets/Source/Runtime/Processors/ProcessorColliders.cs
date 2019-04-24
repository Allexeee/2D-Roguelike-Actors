//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public class ProcessorColliders : Processor
{
    Group<ComponentCollider> groupColliders;
    public ProcessorColliders()
    {
        groupColliders.onAdd += AwakeInGroupOfColliders;
    }
    void AwakeInGroupOfColliders(in ent entity)
    {
        entity.ComponentCollider().source = entity.Get<Collider>();
    }

}