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

    [Header("Positional Data")]
    [SerializeField] public Collider2D hitBox;
    [SerializeField] public Transform groundCheckTransform; //The transform from where the wall check raycast points originate

    [Header("Extra Data")]
    [SerializeField] public PlayerController player;

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

    //Sets the Velocity to Zero to stop all movement
    public void StopMoving()
    {
        _rgbd2.velocity = Vector2.zero; 
    }

    //Method that allows movement along the X Axis
    public void MoveXDirection(float xDir, float MoveSpeed)
    {
        _rgbd2.velocity = new Vector2(xDir * MoveSpeed * Time.deltaTime, 0);
    }

    //Method that allows movement along the Y axis
    public void MoveYDirection(float yDir, float MoveSpeed)
    {
        _rgbd2.velocity = new Vector2(0, yDir * MoveSpeed * Time.deltaTime);
    }

    //Gets assign a direction and speed to move
    private void MoveDirection(float xDir, float yDir, float MoveSpeedX, float MoveSpeedY)
    {
        _rgbd2.velocity = new Vector2(xDir * MoveSpeedX * Time.deltaTime,
                                                                        yDir * MoveSpeedY * Time.deltaTime);
    }

    private void IsPlayerClose()
    {
        if(player.transform.position.x - this.transform.position.x <= entityData.avoidDistance)
        {
            //TODO: FINISH This to allow the Enemies to see how close the player is and further allow them to move away or closer to the player
        }
    }
}