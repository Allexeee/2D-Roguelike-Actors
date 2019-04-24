//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public class Starter_01 : Starter
{
    protected override void Setup()
    {
        Add<ProcessorColliders>();

        FactoryBoard.Spawn();
    }
}