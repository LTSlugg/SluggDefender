using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Component Variables
    private Rigidbody2D _rgbd2;

    //Raycast Transform Locations - The Eyes of the AI
    [SerializeField] Transform _RayCastAimDown;

    //Raycast Variables
    private RaycastHit2D rayCastDown;
    private RaycastHit2D rayCastUp;
    private RaycastHit2D rayCastDownLeft;
    private RaycastHit2D rayCastDownRight;


    //Stat Variables
    [Header("Enemy Stats")]
    [SerializeField] float _MoveSpeed = 3f;

    [Header("Enemy AI Config")]
    [SerializeField] bool CanSeeBelow;


    //States
    private enum States{Spawn, Idle, Patrol, Abduct, Hunt};

    [SerializeField]private States _currentState;

    //Monobehaviour Logic
    void Start()
    {
        _currentState = States.Idle;

        _rgbd2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ActivateVision();
        ActivateMovement();
    }




    //Collision Logic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") ||
                                        collision.CompareTag("Player") ||
                                                                    collision.CompareTag("Enemy")) 
            { OnDeath(); } //Calls on Death Function when colliding with player, bullet, or enemy
    }



    #region Front Door Logic
    private void ActivateVision() //Used to determine the functionality of this AI Enemy IE can it look below, at angles etc
    {
        LookForTargetBelow();
    }
    //TODO: Finish all Available States
    private void ActivateMovement() //Calls the MovementCoroutine
    {
        switch (_currentState)
        {
            case States.Spawn:
                break;

            case States.Idle:
                OnIdle();
                break;

            case States.Patrol:
                OnPatrol();
                break;

            case States.Abduct:
                break;

            case States.Hunt:
                break;
        }
    }
    #endregion



    #region Back Door Logic
    private void OnDeath() //Death Functionality
    {
        //TODO: Implement Death Visual Effect
        Destroy(this.gameObject);
    }

    private void OnSpawn()
    {

    }

    private void OnAbduct()
    {
        StopCoroutine("IdleWaitLogic");
        StopCoroutine("MoveLeftRight");
        StartCoroutine("AbductHuman");
    }

    private void OnPatrol() //Starts the movement Coroutine
    {
        StopCoroutine("IdleWaitLogic");
        StartCoroutine("MoveLeftRight");
    }

    private void OnIdle() //Resets and Randomizes the move direction
    {
        StopCoroutine("MoveLeftRight");
        StartCoroutine("IdleWaitLogic");
    }
    #endregion



    #region AI Logic
    private void LookForTargetBelow() //Uses a Raycast to look DOWN for a Target. This can be the Human or Player, then determines what the next state is.
    {
        rayCastDown = Physics2D.Raycast(_RayCastAimDown.position, Vector2.down);

        if (rayCastDown.collider != null) //Ensures the collider is not null
        {
            switch (rayCastDown.collider.tag) //Checks the tag of what the raycast saw then changes the current State
            {
                case "Human":
                    Debug.Log("Abduct Human");
                    _currentState = States.Abduct;
                    break;

                case "Player":
                    Debug.Log("Hunt Player");
                    _currentState = States.Hunt;
                    break;
            }
        }
    }

    //Enum Variables
    private int RandomMoveDirection; //The direction that is randomly chosen to Move
    private IEnumerator MoveLeftRight() //Moves this Enemy Left and Right for a period of time
    {
        _rgbd2.velocity = new Vector2(_MoveSpeed * RandomMoveDirection * Time.deltaTime, 0);

        yield return new WaitForSeconds(4f);

        _rgbd2.velocity = Vector2.zero; //Stops Moving
        _currentState = States.Idle;
    }

    private IEnumerator IdleWaitLogic() //The Idle waiting Logic
    {
        yield return new WaitForSeconds(0f); //Waits a random amount between 1-2f seconds
        RandomMoveDirection = Random.Range(-1, 2); //Sets the move Direction to either left or right randomly
      
        _currentState = States.Patrol; //Sets state back to patrol
    }
    
    private IEnumerator AbductHuman() //TODO: Finish this Functionality
    {
        _rgbd2.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
    }
    
    
    #endregion
}
