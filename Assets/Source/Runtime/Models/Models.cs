//Framework version:24.04.2019
using UnityEngine;
using Pixeye;
using Pixeye.Framework;

public static partial class Models
{
    ///<summary>
    ///Модель с коллайдером
    ///</summary>
    public static void ModelCollider(EntityComposer composer)
    {
        composer.Add<ComponentCollider>();
    }

    ///<summary>
    ///Модель с физикой - колайдер + рижидбоди
    ///</summary>
    public static void ModelPhisic(EntityComposer composer)
    {
        composer.Add<ComponentCollider>();
        composer.Add<ComponentRigid>();
    }

    ///<summary>
    ///Модель игрока
    ///</summary>
    public static void ModelPlayer(EntityComposer composer)
    {
        composer.Add<ComponentPlayer>();
        composer.Add<ComponentCollider>();
        composer.Add<ComponentRigid>();

        var cInput = composer.Add<ComponentInput>();

        cInput.InputMoveUp = KeyCode.UpArrow;
        cInput.InputMoveDown = KeyCode.DownArrow;
        cInput.InputMoveLeft = KeyCode.LeftArrow;
        cInput.InputMoveRight = KeyCode.RightArrow;
    }
}