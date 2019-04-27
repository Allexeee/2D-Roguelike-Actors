//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public static class Phys
{
    public static ent Entity(this Collider2D collider)
    {
        // collider.print("ef " + collider.GetComponentInParent<Actor>().entity.id);
        return collider.GetComponentInParent<Actor>().GetEntity();
    }
}