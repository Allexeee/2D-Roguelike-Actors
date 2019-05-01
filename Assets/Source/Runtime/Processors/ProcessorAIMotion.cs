//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Процессор движения AI
///</summary>
public class ProcessorAIMotion : Processor
{
    [GroupBy(Tag.CanMotion, Tag.Enemy)]
    Group<ComponentRigid, ComponentCollider> groupAIMotions;

    [GroupBy(Tag.Player)]
    Group<ComponentRigid, ComponentCollider> groupPlayers;

    public ProcessorAIMotion()
    {
        groupAIMotions.onAdd += AwakeInGroupOfAIMotions;
    }

    void AwakeInGroupOfAIMotions(in ent entity)
    {
        foreach (var eAI in groupAIMotions)
        {
            ent eFindedPlayer = FindNearestPlayer(eAI);
            this.print($"Ближайший игрок к ({eAI.id}) = ({eFindedPlayer.id})");
            Vector2Int dir = default(Vector2Int);
            if (eFindedPlayer != -1)
            {
                dir = CalculateDirectionMove(eAI.transform.position, eFindedPlayer.transform.position);
            }
            this.print($"Направление движения AI ({eAI.id}): {dir}");
            eAI.Add<ComponentMotion>().target = dir;
            // ProcessorSignals.Send(new SignalEndMotion { entity = eAI });
        }
    }

    ///<summary>
    ///Поиск ближайшего игрока по "прямой"
    ///</summary>
    ent FindNearestPlayer(ent eAI)
    {
        ent nearestPlayer = -1;
        float minDis = 100f;
        foreach (var item in groupPlayers)
        {
            var dis = Vector3.Distance(item.transform.position, eAI.transform.position);
            if (dis < minDis)
            {
                minDis = dis;
                nearestPlayer = item;
            }
        }
        return nearestPlayer;
    }

    ///<summary>
    ///Простой выбор движения
    ///</summary>
    Vector2Int CalculateDirectionMove(Vector3 self, Vector3 target)
    {
        Vector2Int vec = default(Vector2Int);

        if (Mathf.Abs(self.x - target.x) < float.Epsilon)
            vec.y = target.y > self.y ? 1 : -1;
        else
            vec.x = target.x > self.x ? 1 : -1;

        return vec;
    }
}