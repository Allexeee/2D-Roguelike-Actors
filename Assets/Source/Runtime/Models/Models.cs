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
        composer.Add<ComponentCollider>();
        composer.Add<ComponentRigid>();

        var cPlayer = composer.Add<ComponentPlayer>();
        cPlayer.wallDamage = 1;
        var cInput = composer.Add<ComponentInput>();

        cInput.InputMoveUp = KeyCode.UpArrow;
        cInput.InputMoveDown = KeyCode.DownArrow;
        cInput.InputMoveLeft = KeyCode.LeftArrow;
        cInput.InputMoveRight = KeyCode.RightArrow;
    }

    ///<summary>
    ///Модель стены
    ///</summary>
    public static void ModelWall(EntityComposer composer)
    {
        composer.Add<ComponentDamage>();
        composer.Add<ComponentCollider>();
        var cWall = composer.Add<ComponentWall>();
        // cWall.Health = 3;
    }
}