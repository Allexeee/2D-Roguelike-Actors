//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
/// Компонент здоровья
///</summary>
[Serializable]
public class ComponentHealth : IComponent
{
    public int Health;
    public Interactables.GeneralBase ActionHealthChanged;    

    public void Copy(int entityID)
    {
        var component = Storage<ComponentHealth>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentHealthInit() =>
        Storage<ComponentHealth>.Instance.Creator = () => { return new ComponentHealth(); };

    public static ComponentHealth ComponentHealth(this in ent entity) =>
        Storage<ComponentHealth>.Instance.components[entity.id];
}