//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using System.Collections.Generic;
using System.Collections;
using Time = Pixeye.Framework.Time;

///<summary>
/// Процессор движения
///</summary>
//FIXME Оптимизировать код
public class ProcessorMotion : Processor
{
    Group<ComponentMotion, ComponentRigid, ComponentCollider> groupMotions;

    private float inverseMoveTime = 1f / GameSession.Default.MoveTime;
    private LayerMask blockingLayer = GameSession.Default.blockingLayer;
    private Collider2D lastCollider;

    private ent entity;

    public ProcessorMotion()
    {
        groupMotions.onAdd += AwakeInGroupOfMotions;
    }

    void AwakeInGroupOfMotions(in ent entity)
    {
        var cMotion = entity.ComponentMotion();

        this.entity = entity;

        AttemptMove(cMotion.target.x, cMotion.target.y);

        // Убираем компонент, чтобы сущность попала сюда в след. раз при добавлении компонента
        entity.Remove<ComponentMotion>();
    }

    // Проверяет на присутвие припятствия на пути и двигает объект
    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        bool obstacle = true;

        var cCollider = entity.ComponentCollider();

        Vector2 start = entity.transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        // Отключаем коллайдеры перед поиском новых
        cCollider.source.enabled = false;
        if (lastCollider != null) lastCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        cCollider.source.enabled = true;
        if (lastCollider != null) lastCollider.enabled = true;

        var col = hit.collider;

        if (col != null && col.isTrigger == true)
            lastCollider = col;
        if (col == null)
        {
            lastCollider = null;
            obstacle = false;
        }
        if (col == null || col.isTrigger == true)
        {
            Toolbox.Instance.StartCoroutine(SmoothMovement(entity, end));
        }

        return obstacle;
    }

    //"Плавное" движение
    IEnumerator SmoothMovement(ent entity, Vector3 end)
    {
        var cRigid = entity.ComponentRigid();

        float sqrRemainingDistance = (entity.transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(cRigid.source.position, end, inverseMoveTime * Time.delta);
            cRigid.source.MovePosition(newPostion);
            sqrRemainingDistance = (entity.transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    void AttemptMove(int xDir, int yDir)
    {
        RaycastHit2D hit;

        bool obstacle = Move(xDir, yDir, out hit);
        // this.print(obstacle);
        // if (hit.transform != null)

        if (hit.transform == null)
            return;
            this.print(hit.collider + " " + hit.collider.isTrigger);

        //Get a component reference to the component of type T attached to the object that was hit

        //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
        if (obstacle)
        {
            var entityTarget = hit.transform.GetComponentInParent<Actor>().entity;
            var cCollider = entity.ComponentCollider();
            foreach (var action in cCollider.Actions)
            {
                action.Interact(entity, entityTarget, hit.collider.isTrigger);
            }
        }

        //Call the OnCantMove function and pass it hitComponent as a parameter.
        // OnCantMove(actor.entity);
    }
    //The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    //OnCantMove will be overriden by functions in the inheriting classes.
    protected void OnCantMove(ent enity)
    {
        //enity.Ge
    }

}