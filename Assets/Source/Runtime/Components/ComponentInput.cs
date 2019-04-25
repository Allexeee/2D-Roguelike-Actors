//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

[Serializable]
public class ComponentInput : IComponent
{
    public KeyCode InputMoveRight;
    public KeyCode InputMoveLeft;
    public KeyCode InputMoveUp;
    public KeyCode InputMoveDown;

    public void Copy(int entityID)
    {
        var component = Storage<ComponentInput>.Instance.GetFromStorage(entityID);
    }

    public void Dispose()
    {
    }

}

public static partial class HelperComponents
{
    [RuntimeInitializeOnLoadMethod]
    static void ComponentInputInit() => Storage<ComponentInput>.Instance.Creator = () => { return new ComponentInput(); };

    public static ComponentInput ComponentInput(this in ent entity) =>
        Storage<ComponentInput>.Instance.components[entity.id];
}