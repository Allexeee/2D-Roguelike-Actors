//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

///<summary>
///Стартер уровня
///</summary>
public class Starter_01 : Starter
{
    protected override void Setup()
    {
        Add<ProcessorGame>();
        Add<ProcessorPlayerInput>();

        FactoryBoard.Spawn();
    }
}