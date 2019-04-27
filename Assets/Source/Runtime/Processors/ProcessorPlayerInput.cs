//Framework version:24.04.2019
using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Процессор ввода от игрока
///</summary>
public class ProcessorPlayerInput : Processor, ITick
{
    public Group<ComponentPlayer, ComponentInput, ComponentRigid> groupOfPlayers;

    public void Tick()
    {
        foreach (var entity in groupOfPlayers)
        {
            var cInput = entity.ComponentInput();
            var cRigid = entity.ComponentRigid();

            var velocity = cRigid.source.velocity;

            var moveLeft = Input.GetKeyDown(cInput.InputMoveLeft);
            var moveRight = Input.GetKeyDown(cInput.InputMoveRight);
            var moveUp = Input.GetKeyDown(cInput.InputMoveUp);
            var moveDown = Input.GetKeyDown(cInput.InputMoveDown);

            if (moveDown || moveLeft || moveRight || moveUp)
            {
                var cMotion = entity.Add<ComponentMotion>();
                if(moveLeft) cMotion.target = new Vector2(-1,0);
                else if(moveDown) cMotion.target = new Vector2(0,-1);
                else if(moveRight) cMotion.target = new Vector2(1,0);
                else if(moveUp) cMotion.target = new Vector2(0,1);
                // this.print(cMotion.target);
            }
        }
    }
}
