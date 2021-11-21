using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    /*
     * Tracks when the state has started, great tool for wait time checks within the state
     */


    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime; //Tracks when the state starts


     //Constructor modifiers to intialize when instanced
    public States(Entity entity, FiniteStateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }

    //Do Something when Entering the State
    public virtual void Enter() {
        startTime = Time.time; //When the state has started
    }

    //Do Something when Exiting the State
    public virtual void Exit() 
    {
    }

    public virtual void LogicUpdate() //The Update() Method via Monobehavior of the Current State
    {
    }

    public virtual void PhysicsUpdate() //The FixedUpdate() Method via Monobehavior of the Current State
    {
    }
}
