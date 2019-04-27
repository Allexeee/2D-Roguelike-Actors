//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

[Serializable]
public class ComponentWall : IComponent
{
    public int Health;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentWall>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentWallInit() =>
        Storage<ComponentWall>.Instance.Creator = () => { return new ComponentWall(); };

    public static ComponentWall ComponentWall(this in ent entity) =>
        Storage<ComponentWall>.Instance.components[entity.id];
}