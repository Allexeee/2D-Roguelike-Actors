//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public static class Phys
{
    public static ref ent GetEntityInParent(this RaycastHit2D hit)
    {
        return ref hit.collider.GetComponentInParent<Actor>().entity;
    }
}