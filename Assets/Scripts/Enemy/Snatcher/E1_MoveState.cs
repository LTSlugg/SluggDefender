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
        
        if(moveDirectionXWorkspace == 0) { moveDirectionXWorkspace = Random.Range(-1, 2); } //Rolls the random range on the variable once more in case of 0

        Debug.Log("In Move State");
    }


    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (snatcherEntity.CheckGroundForHuman()) //Checks the ground for a human and Transitions into abduct state if true
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.abductState);
        }
        else if (Time.time >= startTime + patrolTime) //Transitions to the idle state if patrol time is over
        {
            snatcherEntity.stateMachine.ChangeState(snatcherEntity.idleState);
        }
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!snatcherEntity.CheckGroundForHuman())
        {
            MoveRandomXDirection(); //Calls the Method that allows for movement along X Axis
        }

    }


    //TODO: Extrapolate MOVEMENT Methods into the base State class to allow all derived classes the functionality
    //Method that allows movement along the X Axis in a direction determined by the xDirection Workspace Variable
    private void MoveRandomXDirection()
    {
        snatcherEntity._rgbd2.velocity = new Vector2(moveDirectionXWorkspace * stateData.MoveSpeed * Time.deltaTime, 0);
    }
}
