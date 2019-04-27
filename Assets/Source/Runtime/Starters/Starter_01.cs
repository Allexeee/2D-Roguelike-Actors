//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using Time = Pixeye.Framework.Time;

///<summary>
///Стартер уровня
///</summary>
public class Starter_01 : Starter
{
    protected override void Setup()
    {
        Add<ProcessorGame>();
        Add<ProcessorPlayerInput>();
        Add<ProcessorMotion>();
        Add<ProcessorCollisition>();

        // FactoryBoard.Spawn();
        var aWall = Actor.Create("Prefabs/obj_Wall1", Models.ModelWall);
        var a = Actor.Create("Prefabs/obj_Player", Models.ModelPlayer);
        a.transform.position = new Vector2(1, 1);

        this.print("Стена. id:" + aWall.entity.id);
        this.print("Стена. " + aWall.entity.ComponentWall());

        Timer.Add(Time.delta, () =>
        {
            this.print("Стена. Задержка в кадр. id:" + aWall.entity.id);
            this.print("Стена. Задержка в кадр. " + aWall.entity.ComponentWall());
        });
    }
}