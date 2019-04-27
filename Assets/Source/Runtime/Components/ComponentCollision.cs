//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

[Serializable]
public class ComponentCollision : IComponent
{
    public ent targetEntity;
    public Collider2D targetCollider;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentCollision>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentCollisionInit() =>
        Storage<ComponentCollision>.Instance.Creator = () => { return new ComponentCollision(); };

    public static ComponentCollision ComponentCollision(this in ent entity) =>
        Storage<ComponentCollision>.Instance.components[entity.id];
}