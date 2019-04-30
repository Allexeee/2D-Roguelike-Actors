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
    ///Модель врага
    ///</summary>
    public static void ModelEnemy(EntityComposer composer)
    {
        composer.Add<ComponentCollider>();
        composer.Add<ComponentRigid>();
        
        composer.Add(Tag.Enemy);
    }

    ///<summary>
    ///Модель игрока
    ///</summary>
    public static void ModelPlayer(EntityComposer composer)
    {
        composer.Add<ComponentRigid>();

        var cCollider = composer.Add<ComponentCollider>();
        cCollider.Actions = new Interactables.CollisionBase[1];
        cCollider.Actions[0] = Scriptables.Damage;

        var cPlayer = composer.Add<ComponentDamageWall>();
        cPlayer.wallDamage = 1;

        var cInput = composer.Add<ComponentInput>();
        cInput.InputMoveUp = KeyCode.UpArrow;
        cInput.InputMoveDown = KeyCode.DownArrow;
        cInput.InputMoveLeft = KeyCode.LeftArrow;
        cInput.InputMoveRight = KeyCode.RightArrow;

        var cAnim = composer.Add<ComponentAnim>();
        cAnim.source = Box.Get<RuntimeAnimatorController>("Animation/Controllers/Animator Player");
        cAnim.current = Anim.PlayerIdle;

        composer.Add(Tag.Player);
    }

    ///<summary>
    ///Модель стены
    ///</summary>
    public static void ModelWall(EntityComposer composer)
    {
        composer.Add<ComponentCollider>();
        var cHealth = composer.Add<ComponentHealth>();
        cHealth.Health = 4;
        cHealth.ActionHealthChanged = Scriptables.WallsCollapsing;

        composer.Add(Tag.Wall);
    }
}