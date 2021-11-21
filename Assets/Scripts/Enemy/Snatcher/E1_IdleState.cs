using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{

    private E1_Snatcher snatcherEntity;

    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, D_IdleState stateData, E1_Snatcher snatcherEntity) : base(entity, stateMachine, stateData)
    {
        this.snatcherEntity = snatcherEntity;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("In Idle State"); //TODO: Remove This Debug Log
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Checks to see if the wait time is over then changes the current state
        if(IsDefaultWaitTimeOver())
        {
            stateMachine.ChangeState(snatcherEntity.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
