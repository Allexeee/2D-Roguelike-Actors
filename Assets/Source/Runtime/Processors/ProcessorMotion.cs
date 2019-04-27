//Framework version:24.04.2019

using System;
using UnityEngine;
using Pixeye;
using Pixeye.Framework;
using System.Collections.Generic;
using System.Collections;
using Time = Pixeye.Framework.Time;

public class ProcessorMotion : Processor
{

	Group<ComponentMotion, ComponentRigid, ComponentCollider> groupMotions;

	private float inverseMoveTime = 1f / GameSession.Default.MoveTime;
	private LayerMask blockingLayer = GameSession.Default.blockingLayer;

	private ent entity;

	public ProcessorMotion()
	{
		groupMotions.onAdd += AwakeInGroupOfMotions;
	}

	void AwakeInGroupOfMotions(in ent entity)
	{
		var cMotion = entity.ComponentMotion();

		this.entity = entity;

		AttemptMove(cMotion.target.x, cMotion.target.y);

		// Убираем компонент, чтобы сущность попала сюда в след. раз при добавлении компонента
		entity.Remove<ComponentMotion>();
	}

	//Move returns true if it is able to move and false if not. 
	//Move takes parameters for x direction, y direction and a RaycastHit2D to check collision.
	protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
	{
		var cCollider = entity.ComponentCollider();

		Vector2 start = entity.transform.position;
		Vector2 end = start + new Vector2(xDir, yDir);

		cCollider.source.enabled = false;
		hit = Physics2D.Linecast(start, end, blockingLayer);
		cCollider.source.enabled = true;
		if (hit.transform == null)
		{
			Toolbox.Instance.StartCoroutine(SmoothMovement(entity, end));
			return true;
		}

		return false;
	}

	//"Плавное" движение
	IEnumerator SmoothMovement(ent entity, Vector3 end)
	{
		var cRigid = entity.ComponentRigid();

		float sqrRemainingDistance = (entity.transform.position - end).sqrMagnitude;
		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPostion = Vector3.MoveTowards(cRigid.source.position, end, inverseMoveTime * Time.delta);
			cRigid.source.MovePosition(newPostion);
			sqrRemainingDistance = (entity.transform.position - end).sqrMagnitude;
			yield return null;
		}
	}

	void AttemptMove(int xDir, int yDir)
	{
		RaycastHit2D hit;

		bool canMove = Move(xDir, yDir, out hit);

		// if (hit.transform == null)
		// return;

		//Get a component reference to the component of type T attached to the object that was hit
		// Actor actor = hit.transform.GetComponent<Actor>();

		//If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
		if (!canMove)
		{
			var a = hit.collider.GetComponentInParent<Actor>();
		 
			if (a != null)
			{
			 
				if (a.entity.Get(out ComponentHealth cHealth))
				{
					ref var hp = ref cHealth.hp;
				 Debug.Log(hp);
					if (--hp == 0)
					{
						a.entity.Release();
					}
				}
			}
//            var cCollision = entity.Add<ComponentCollision>();
//            cCollision.targetEntity = hit.collider.GetComponentInParent<Actor>().GetEntity();
//            // cCollision.targetEntity.Add<ComponentWall>();
//            cCollision.targetCollider = hit.collider;
//
//            this.print("Столкновение. Цель: " + cCollision.targetEntity.id + " " + hit.transform.parent.name);
//            this.print(hit.collider.GetComponentInParent<Actor>().GetEntity().ComponentWall() + " ЭЭЭ"); //null

			// cCollision.targetEntity = hit.collider.Entity();
			// this.print("Столкновение. Источник: " + entity.id);
		}

		//Call the OnCantMove function and pass it hitComponent as a parameter.
		// OnCantMove(actor.entity);
	}

	//The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
	//OnCantMove will be overriden by functions in the inheriting classes.
	protected void OnCantMove(ent enity)
	{
		//enity.Ge
	}

}