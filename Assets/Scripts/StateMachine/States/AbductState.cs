using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductState : States
{
    protected D_AbductState stateData;

    public AbductState(Entity entity, FiniteStateMachine stateMachine, D_AbductState stateData) : base(entity, stateMachine)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity._rgbd2.velocity = Vector2.zero; //Sets the Velocity to Zero on state entry to stop all movement
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
}
