using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abduct State handles the entity moving downward towards the Human until it collides with it
//Then this state will transition into the Escape State

public class E1_AbductState : States
{
    private E1_Snatcher snatcherEntity;
    protected D_AbductState stateData;

    public E1_AbductState(Entity entity, FiniteStateMachine stateMachine, D_AbductState stateData, E1_Snatcher snatcherEntity) : base(entity, stateMachine)
    {
        this.stateData = stateData;
        this.snatcherEntity = snatcherEntity;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("In Abduct State"); //TODO: REMOVE THIS DEBUG LOG
        snatcherEntity.StopMoving();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(snatcherEntity.didCollideWithHuman)
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.escapeState);
        }


        else if (!snatcherEntity.CheckGroundForHuman()) //IF the Human leaves the vision of the snatcher entity he goes back to Idle
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(!snatcherEntity.didCollideWithHuman)
        {
            snatcherEntity.MoveYDirection(Vector2.down.y, stateData.abductMoveSpeedDown);
        }
    }
}
