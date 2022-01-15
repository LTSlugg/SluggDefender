using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Default State that is entered by the Snatcher entity
 */

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
        Debug.Log("In Idle State"); //TODO: REMOVE THIS DEBUG LOG
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        AbductHumanLogic();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //Scans the ground for a Human, then resets to the Idle State of nothing is found within the patrol time
    private void AbductHumanLogic()
    {
        if (snatcherEntity.CheckGroundForHuman()) //Checks the ground for a human and Transitions into abduct state if true
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.abductState);
        }

        //Checks to see if the wait time is over then changes the current state
        else if(IsDefaultWaitTimeOver())
        {
            stateMachine.ChangeState(snatcherEntity.moveState);
        }
    }
}
