//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Компонент нанесения урона стенам
///</summary>
[Serializable]
public class ComponentDamageWall : IComponent
{
    public int wallDamage;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentDamageWall>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentDamageWallInit() =>
        Storage<ComponentDamageWall>.Instance.Creator = () => { return new ComponentDamageWall(); };

    public static ComponentDamageWall ComponentDamageWall(this in ent entity) =>
        Storage<ComponentDamageWall>.Instance.components[entity.id];
}