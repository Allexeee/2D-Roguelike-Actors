//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public static partial class Models
{
    public static void ModelCollider(EntityComposer composer)
    {
        composer.Add<ComponentCollider>();
    }
}