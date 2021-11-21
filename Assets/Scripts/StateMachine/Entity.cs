using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Entity class handles most of the base function any Enemy will do, like Set velocity, set movement direction, face and follow player. ETC....
 */

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public Rigidbody2D _rgbd2 { get; private set; }
    public SpriteRenderer _renderer { get; set; }

    public D_Entity entityData;


    [SerializeField] public Collider2D hitBox;
    [SerializeField] public Transform groundCheckTransform; //The transform from where the wall check raycast points originate


    //public D_Entity entityData; //Ref to the Data File


    //Start function monobehaviour
    public virtual void Start() 
    {
        stateMachine = new FiniteStateMachine(); //new instance of the statemachine

        _rgbd2 = transform.gameObject.GetComponent<Rigidbody2D>(); //reference component
        _renderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }



    //Calls the statemachines current state logic update
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }


    //Calls the statemachines current state physic update function
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    //Does a check using raycast and returns what it hits
    public virtual bool CheckGroundForHuman()
    {
        RaycastHit2D ray = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, entityData.raycastDownDistance);

        if (ray.collider.tag == entityData.whatIsHuman)
        { return true; }
        
        else
        {   return false; }
    }
}