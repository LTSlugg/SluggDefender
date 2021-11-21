using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abduct State handles the entity moving downward towards the Human until it collides with it
//Then this state will transition into the Escape State

public class E1_AbductState : AbductState
{
    private E1_Snatcher snatcherEntity;

    private int downDirectionY = -1;

    public E1_AbductState(Entity entity, FiniteStateMachine stateMachine, D_AbductState stateData, E1_Snatcher snatcherEntity) : base(entity, stateMachine, stateData)
    {
        this.snatcherEntity = snatcherEntity;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("In Abduct State");
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
            Debug.Log("I hit a human, transition to escape state");
            //TODO: Add Transition to Escape state
            snatcherEntity._rgbd2.velocity = Vector2.zero;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(!snatcherEntity.didCollideWithHuman)
        {
            MoveDown();
        }
    }

    //TODO: Extrapolate MOVEMENT Methods into the base State class to allow all derived classes the functionality
    //Method that moves the enemy downward
    private void MoveDown()
    {
        snatcherEntity._rgbd2.velocity = new Vector2(0, downDirectionY * stateData.abductMoveSpeedDown * Time.deltaTime);
    }
}
