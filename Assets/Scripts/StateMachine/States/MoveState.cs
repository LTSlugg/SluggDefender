using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : States
{
    protected D_MoveState stateData;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, D_MoveState stateData) : base(entity, stateMachine)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
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
