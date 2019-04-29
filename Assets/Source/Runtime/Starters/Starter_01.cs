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
        Add<ProcessorTurn>();
    }

    protected override void PostSetup()
    {
        FactoryBoard.Spawn();
        var arg = new SignalEndMotion { entity = -1 };
        Timer.Add(Time.delta, () => ProcessorSignals.Send(arg));

    }
}