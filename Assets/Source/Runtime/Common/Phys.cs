//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public static class Phys
{
    private static PhysCheckHit PhysCheckHit = new PhysCheckHit();

    public static PhysCheckHit CheckHit(this RaycastHit2D hit)
    {
        PhysCheckHit.CheckHit(hit);
        return PhysCheckHit;
    }

    public static ent GetEntityInParent(this RaycastHit2D hit)
    {
        return hit.collider.GetComponentInParent<Actor>().entity;
    }
}

public class PhysCheckHit
{
    public bool IsCollider;
    public bool IsTrigger;
    public bool IsActor;
    public ent Entity = -1;

    public Collider2D Collider2D;

    public void CheckHit(RaycastHit2D hit)
    {
        IsCollider = default(bool);
        IsTrigger = default(bool);
        IsActor = default(bool);
        Entity = -1;
        Collider2D = hit.collider;
        
        if (Collider2D)
        {
            IsCollider = true;
            IsTrigger = Collider2D.isTrigger;
            var act = Collider2D.GetComponentInParent<Actor>();
            if (act != null)
            {
                IsActor = true;
                Entity = act.GetEntity();
            }
        }
    }
    // public void CheckHit(RaycastHit2D hit, out Collider2D collider)
    // {
    //     collider = hit.collider;
    //     if (hit.collider) IsCollider = true;

    //     var act = hit.collider.GetComponentInParent<Actor>();
    //     if (act != null)
    //     {
    //         IsActor = true;
    //         Entity = act.GetEntity();
    //     }
    // }

    // public void CheckHit(this RaycastHit2D hit, out Collider2D collider, out Actor actor)
    // {
    //     collider = hit.collider;
    //     if (hit.collider) IsCollider = true;

    //     var act = hit.collider.GetComponentInParent<Actor>();
    //     actor = act;
    //     if (act != null)
    //     {
    //         IsActor = true;
    //         Entity = act.GetEntity();
    //     }
    // }
}