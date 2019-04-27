//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using System;

///<summary>
///Компонент с коллайдером
///</summary>
[Serializable]
public class ComponentCollider : IComponent
{
    public Collider2D source;
    // Действия при столкновении
    public Interactables.CollisionBase[] Actions;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentCollider>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
        source = null;
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentColliderInit()
    {
        Storage<ComponentCollider>.Instance.Creator = () => { return new ComponentCollider(); };
    }

    public static ComponentCollider ComponentCollider(this in ent entity)
    {
        return Storage<ComponentCollider>.Instance.components[entity];
    }

}