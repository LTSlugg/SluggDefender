using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The derived class of a enemy type, handles tracking all the states
 */

public class E1_Snatcher : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_AbductState abductState { get; private set; }
    public E1_EscapeState escapeState { get; private set; }

    [Header("State Datas")]
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_AbductState abductStateData;
    [SerializeField]
    private D_EscapeState escapeStateData;

    public bool didCollideWithHuman { get; private set; }
    
    public override void Start()
    {
        base.Start();

        //Create instances of our state objects and fill constructors
        idleState = new E1_IdleState(this, stateMachine, idleStateData, this);
        moveState = new E1_MoveState(this, stateMachine, moveStateData, this);
        abductState = new E1_AbductState(this, stateMachine, abductStateData, this);
        escapeState = new E1_EscapeState(this, stateMachine, escapeStateData, this);


        didCollideWithHuman = false;
        stateMachine.Intialize(idleState); //Sets the default state to Idle on start
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }



    //Checks for Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != null)
        {
            if(collision.tag == "Human")
            {
                didCollideWithHuman = true;
            } 

            //Destroys Itself on Collision with Player
            if(collision.tag == "Player" || collision.tag == "Bullet")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
