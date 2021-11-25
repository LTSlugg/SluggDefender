using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//**IF Statements Galore** (Screw it lets speed this up)
//Handles all of the Logic functionality of all the Humans the player must save, it works great, lots of if statements and booleans but works great

public class HumanAI : MonoBehaviour
{
    //TODO: Observer Pattern - Assign into the GameSystem.cs to track win conditions



    //Data Variables
    [SerializeField]private Entity _currentEnemy;
    [SerializeField]private PlayerController _currentPlayer;

    [Header("States")]
    [SerializeField] public bool IsAbducted = false;
    [SerializeField] public bool CanBeAbducted = true;
    [SerializeField] private bool IsGrounded = false;
    [SerializeField] public bool IsSaved = false;
    [SerializeField] private bool CanDie = false;

    [Header("Attributes")]
    [SerializeField] private float viewDistance = 1f;
    [SerializeField] Transform _GroundedTransform;
    [SerializeField] private float fallRate = 60f;


    private RaycastHit2D rayCastDown;


    private void FixedUpdate()
    {
        GetAbducted();
        GetSaved();
        CheckIfGrounded();
        Fall();
    }

    private void GetAbducted() //Anchors the object to the enemy
    {
        if (_currentEnemy == null) { return; } //If Gameobject is null break out of function
        
        this.transform.position = _currentEnemy.groundCheckTransform.position; //Clamps position to the enemies raycast position
    }

    private void GetSaved() //Anchors the object to this player
    {
        if(_currentPlayer == null) { return; }
        if(IsSaved) this.transform.position = _currentPlayer._PlayerCarryTransform.position;
    }

    private void CheckIfGrounded() //Function that uses raycast to see if the object is on the 'ground' layer (For some reason dumbass physics is not working SO HARDCODED WAY IT IS!)
    {
        rayCastDown = Physics2D.Raycast(_GroundedTransform.position, Vector2.down, viewDistance);

        if (rayCastDown.collider == null) { return; }

        if (rayCastDown.collider.tag == "Ground") 
        { 
            IsGrounded = true; 
            
            if(CanDie)
            {
                Die();
            }
            else if(IsSaved)
            {
                Saved();
            }
        }
        
        else if (rayCastDown.collider.tag != "Ground") { IsGrounded = false; }
    }

    private void Fall() //Makes the transform move down until it is grounded
    {
        if(!IsAbducted && !IsGrounded && !IsSaved)
        {
            transform.Translate(0, 
                                    Vector2.down.y * fallRate * Time.deltaTime, 
                                                                                0);
        }
    }
    
    private void Saved() //Resets the Object and scores TODO: Finish Saved functionality with happy and run away animation
    {
        Destroy(this.gameObject, 3f);
        
        IsSaved = false;
        CanDie = false;
        IsAbducted = false;
    }

    private void Die() //Lose condition, the object destroys itself TODO: Finish Death Functionality with explosion vfx
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision) //Checks what has collided with and functions accordingly
    {
        if(collision.tag != null)
        {
            if (collision.CompareTag("Enemy") && IsAbducted == false)
            {
                _currentEnemy = collision.gameObject.GetComponent<Entity>();

                IsAbducted = true;
                CanBeAbducted = false;
            }
            if (collision.CompareTag("Player") && !IsAbducted && !IsGrounded)
            {
                _currentPlayer = collision.gameObject.GetComponent<PlayerController>();

                IsSaved = true;
                CanDie = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != null)
        {
            if (collision.CompareTag("Enemy") && IsAbducted == true)
            {
                IsAbducted = false;
                CanDie = true;
            }
        }
    }
}
