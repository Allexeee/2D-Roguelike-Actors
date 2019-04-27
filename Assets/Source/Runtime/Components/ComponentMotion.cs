//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Компонент с целевой точкой движения
///</summary>
[Serializable]
public class ComponentMotion : IComponent
{
    public Vector2Int target;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentMotion>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }

}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentMotionInit()
    {
        Storage<ComponentMotion>.Instance.Creator = () => { return new ComponentMotion(); };
    }

    public static ComponentMotion ComponentMotion(this in ent entity)
    {
        return Storage<ComponentMotion>.Instance.components[entity.id];
    }
}
