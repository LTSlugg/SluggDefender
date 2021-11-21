using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : States
{
    protected D_IdleState stateData;

    private float idleWaitTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, D_IdleState stateData) : base(entity, stateMachine)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity._rgbd2.velocity = Vector2.zero; //Sets the Velocity to Zero on state entry to stop all movement
        idleWaitTime = Random.Range(stateData.idleWaitTimeMin, stateData.idleWaitTimeMax);
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
    }


    //Checks to see if the idle time is over by comparing the start time + idle wait time in the statedata to the current time
    protected bool IsDefaultWaitTimeOver()
    {
        if(Time.time >= startTime + idleWaitTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
