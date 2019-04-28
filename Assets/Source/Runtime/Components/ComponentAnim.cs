//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

[Serializable]
public class ComponentAnim : IComponent
{
    public RuntimeAnimatorController source;
    public int current;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentAnim>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }
}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentAnimInit() =>
        Storage<ComponentAnim>.Instance.Creator = () => { return new ComponentAnim(); };

    public static ComponentAnim ComponentAnim(this in ent entity) =>
        Storage<ComponentAnim>.Instance.components[entity.id];
}