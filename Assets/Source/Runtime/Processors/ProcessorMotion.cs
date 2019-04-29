//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using System.Collections.Generic;
using System.Collections;
using Time = Pixeye.Framework.Time;

///<summary>
/// Процессор движения. При столкновении (взаимодействии с миром) вызывает обработчики в ComponentCollider
///</summary>
public class ProcessorMotion : Processor, ITick
{
    [GroupBy(Tag.CanMotion)]
    Group<ComponentMotion, ComponentRigid, ComponentCollider> groupMotions;

    private float inverseMoveTime = 1f / GameSession.Default.MoveTime;
    private LayerMask blockingLayer = GameSession.Default.blockingLayer;
    // Для каждой сущности хранит объект, который нужно проигнорировать при следующем поиске припятствия
    private Dictionary<ent, Collider2D> lastColliders = new Dictionary<ent, Collider2D>();

    bool moving;
    public ProcessorMotion()
    {
        groupMotions.onAdd += AwakeInGroupOfMotions;
    }

    public void Tick()
    {
        if (groupMotions.length <= 0) return;
        if (moving) return;
        moving = true;

        var entity = groupMotions[0];
        var cMotion = entity.ComponentMotion();

        Vector2 start = entity.transform.position;
        Vector2 end = start + new Vector2(cMotion.target.x, cMotion.target.y);

        var checkHit = CheckObstacle(entity, start, end);
        // Если припятствие - коллайдер с триггером или нет припятствия, то двигаемся
        if (!checkHit.IsCollider || checkHit.IsTrigger)
        {
            Toolbox.Instance.StartCoroutine(SmoothMovement(entity, end));
        }
        // Припятствие с актором
        else if (checkHit.IsActor)
        {
            var cCollider = entity.ComponentCollider();
            // this.print("checkHit " + checkHit.IsCollider + " Tr: " + checkHit.IsTrigger + " Ac: " + checkHit.IsActor + " En: " + checkHit.Entity.id);
            foreach (var action in cCollider.Actions)
            {
                action.Interact(entity, checkHit.Entity, checkHit.IsTrigger);
            }
            moving = false;
        }
        if (checkHit.IsCollider && !checkHit.IsActor && !checkHit.IsTrigger) moving = false;
        ProcessorSignals.Send(new SignalEndMotion { entity = entity });
        entity.Remove<ComponentMotion>();
    }

    void AwakeInGroupOfMotions(in ent entity)
    {
        if (!lastColliders.ContainsKey(entity)) lastColliders.Add(entity, null);
    }

    ///<summary>
    /// Проверяет на наличие припятствия к точке движения
    ///<param name="eObstacle">Триггер</param>
    ///<param name="return">entity припятствия</param>
    ///</summary>
    private PhysCheckHit CheckObstacle(ent entity, Vector2 start, Vector2 end)
    {
        var cCollider = entity.ComponentCollider();

        // Отключаем коллайдеры перед проверкой припятствия
        cCollider.source.enabled = false;
        if (lastColliders[entity] != null) lastColliders[entity].enabled = false;

        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);

        // Включаем коллайдеры после проверки припятствия
        cCollider.source.enabled = true;
        if (lastColliders[entity] != null) lastColliders[entity].enabled = true;

        var ch = hit.CheckHit();
        if (ch.IsTrigger) lastColliders[entity] = ch.Collider2D;
        return ch;
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
        moving = false;
    }
}