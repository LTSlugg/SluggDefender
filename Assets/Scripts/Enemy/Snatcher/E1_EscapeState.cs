using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * After Abducting a Astronaut the Snatcher enters this state in order to escape the atmosphere and spawn in an Aviator
 */
public class E1_EscapeState : States
{
    private E1_Snatcher snatcherEntity;
    private D_EscapeState stateData;

    public E1_EscapeState(Entity entity, FiniteStateMachine stateMachine, D_EscapeState stateData, E1_Snatcher snatcherEntity ) : base(entity, stateMachine)
    {
        this.snatcherEntity = snatcherEntity;
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("In Escape State"); //TODO: REMOVE THIS DEBUG LOG
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if(!snatcherEntity.isAvoidingPlayer)
            snatcherEntity.MoveYDirection(Vector2.up.y, stateData.escapeSpeed); //Moves up as soon as he latches onto the Human
    }

    //TODO: Add Function that allows Snatcher to slightly move away from the Player as he approaches
}
