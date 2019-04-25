//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

[Serializable]
public class ComponentRigid : IComponent
{
    public Rigidbody2D source;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentRigid>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }

}

public static partial class HelperComponents
{

    [RuntimeInitializeOnLoadMethod]
    static void ComponentRigidInit()
    {
        Storage<ComponentRigid>.Instance.Creator = () => { return new ComponentRigid(); };
    }

    public static ComponentRigid ComponentRigid(this in ent entity)
    {
        return Storage<ComponentRigid>.Instance.components[entity.id];
    }
}