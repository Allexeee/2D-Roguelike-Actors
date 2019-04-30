//Framework version:27.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

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

    Vector2Int CalculateDirectionMove(Vector3 self, Vector3 target)
    {
        Vector2Int vec = default(Vector2Int);

        if (Mathf.Abs(self.x - target.x) < float.Epsilon)
            vec.y = target.y > self.y ? 1 : -1;
        else
            vec.x = target.x > self.x ? 1 : -1;

        return vec;
    }
    //MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
    // public void MoveEnemy()
    // {
    //     //Declare variables for X and Y axis move directions, these range from -1 to 1.
    //     //These values allow us to choose between the cardinal directions: up, down, left and right.
    //     int xDir = 0;
    //     int yDir = 0;

    //     //If the difference in positions is approximately zero (Epsilon) do the following:
    //     if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)

    //         //If the y coordinate of the target's (player) position is greater than the y coordinate of this enemy's position set y direction 1 (to move up). If not, set it to -1 (to move down).
    //         yDir = target.position.y > transform.position.y ? 1 : -1;

    //     //If the difference in positions is not approximately zero (Epsilon) do the following:
    //     else
    //         //Check if target x position is greater than enemy's x position, if so set x direction to 1 (move right), if not set to -1 (move left).
    //         xDir = target.position.x > transform.position.x ? 1 : -1;

    //     //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
    //     AttemptMove<Player>(xDir, yDir);
    // }

}