//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using System.Collections.Generic;

///<summary>
/// Процессор очереди. Управляет ходами.
///</summary>
public class ProcessorTurn : Processor, IReceive<SignalEndMotion>
{
    Group<ComponentCollider, ComponentRigid> groupOfCanMotions;

    List<ent> listTurn = new List<ent>();

    int currentTurn = -1;
    bool sorted = false;

    public ProcessorTurn()
    {
        groupOfCanMotions.onAdd += AwakeInGroupOfCanMotions;
    }

    public void HandleSignal(in SignalEndMotion arg)
    {
        // Группа с "ходящими" сущностями создается лишь один раз (по правилам игры), поэтому сортируем лишь один раз
        if (!sorted)
        {
            sorted = true;
            listTurn.Sort(new EntityComparer());
            // int i = 0;
            // foreach (var item in listTurn)
            // {
            //     this.print("Очередь №" + i++ + " " + item.transform.name + " e:" + item.id);
            // }
        }
        if (listTurn.Count < 0) return;
        var entity = arg.entity;
        // Т.к. первый вызов идет из стартера без указания сущности, то проверяем
        if (entity != -1)
        {
            entity.Remove(Tag.CanMotion);
            // this.print($"RemoveTag CanMotion ({entity.id})");
        }
        if (++currentTurn >= listTurn.Count)
            currentTurn = 0;
        // this.print("Ход " + listTurn[currentTurn].id);
        listTurn[currentTurn].Add(Tag.CanMotion);
    }

    void AwakeInGroupOfCanMotions(in ent entity)
    {
        if (entity.HasAny(Tag.Player, Tag.Enemy))
        {
            listTurn.Add(entity);
        }
    }
}

class EntityComparer : IComparer<ent>
{
    public int Compare(ent x, ent y)
    {
        if (x.Has(Tag.Player) && y.Has(Tag.Enemy))
            return -1;
        if (x.Has(Tag.Enemy) && y.Has(Tag.Player))
            return 1;
        return 0;
    }
}