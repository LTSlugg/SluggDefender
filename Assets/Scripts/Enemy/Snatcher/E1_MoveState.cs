using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private E1_Snatcher snatcherEntity;

    private int moveDirectionXWorkspace;
    private float patrolTime;

    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, D_MoveState stateData, E1_Snatcher snatcherEntity) : base(entity, stateMachine, stateData)
    {
        this.snatcherEntity = snatcherEntity;
    }

    public override void Enter()
    {
        base.Enter();
        
        patrolTime = Random.Range(stateData.MinPatrolTime, stateData.MaxPatrolTime); //Sets the random patrol time
        moveDirectionXWorkspace = Random.Range(-1, 2); //Sets the move direction to a random side   
        if(moveDirectionXWorkspace == 0) { moveDirectionXWorkspace = Random.Range(-1, 2); } //Re Rolls the random range on the variable once more in case of 0

        Debug.Log("In Move State"); //TODO: REMOVE THIS DEBUG LOG
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

        if (!snatcherEntity.CheckGroundForHuman())
        {
            snatcherEntity.MoveXDirection(moveDirectionXWorkspace, stateData.MoveSpeed); //Calls the Method that allows for movement along X Axis
        }
    }


    //Scans the ground for a Human, then resets to the Idle State of nothing is found within the patrol time
    private void AbductHumanLogic()
    {
        if (snatcherEntity.CheckGroundForHuman()) //Checks the ground for a human and Transitions into abduct state if true
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.abductState);
        }
        else if (Time.time >= startTime + patrolTime) //Transitions to the idle state if patrol time is over
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.idleState);
        }
    }
}
