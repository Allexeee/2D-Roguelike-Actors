//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
/// Компонент урона
///</summary>
[Serializable]
public class ComponentDamage : IComponent
{
    public int Damage;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentDamage>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentDamageInit() =>
        Storage<ComponentDamage>.Instance.Creator = () => { return new ComponentDamage(); };

    public static ComponentDamage ComponentDamage(this in ent entity) =>
        Storage<ComponentDamage>.Instance.components[entity.id];
}