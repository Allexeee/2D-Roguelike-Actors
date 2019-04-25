//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Компонент игрока. Пока что пустышка
///</summary>
[Serializable]
public class ComponentPlayer : IComponent
{
    

    public void Copy(int entityID)
    {
        var component = Storage<ComponentPlayer>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentPlayerInit() =>
        Storage<ComponentPlayer>.Instance.Creator = () => { return new ComponentPlayer(); };

    public static ComponentPlayer ComponentPlayer(this in ent entity) =>
        Storage<ComponentPlayer>.Instance.components[entity.id];
}