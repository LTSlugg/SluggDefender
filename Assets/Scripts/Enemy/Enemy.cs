using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Crappy StateMachine I litteraly made on the fly without much thought, this project seemed easy.
public class Enemy : MonoBehaviour
{
    //Component Variables
    private Rigidbody2D _rgbd2;

    //Raycast Transform Locations - The Eyes of the AI
    [SerializeField] public Transform _RayCastAimDown;

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
    private enum States { Spawn, Idle, Patrol, Abduct, Hunt, Escape};

    [SerializeField] private States _currentState;

    //Monobehaviour Logic
    void Start()
    {
        _currentState = States.Idle;

        _rgbd2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //ActivateVision();
        //ActivateMovement();
    }




    //Collision Logic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") ||
                                        collision.CompareTag("Player") || collision.CompareTag("Ground"))
        { OnDeath(); } //Calls on Death Function when colliding with player, bullet

        else if (collision.CompareTag("Human")) _currentState = States.Escape;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherRigidbody.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    #region Front Door Logic
    private void ActivateVision() //Used to determine the functionality of this AI Enemy IE can it look below, at angles etc
    {
        switch (_currentState)
        {
            case States.Spawn:
                break;
            case States.Idle:
                LookForTargetBelow();
                break;
            case States.Patrol:
                LookForTargetBelow();
                break;
            case States.Abduct:
                LookForTargetBelow();
                break;
            case States.Hunt:
                LookForTargetBelow();
                break;
            case States.Escape:
                break;
        }
    
    
    }

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
                OnAbduct();
                break;

            case States.Hunt:
                break;

            case States.Escape:
                OnEscape();
                break;
        }
    }
    #endregion



    #region Back Door Logic
    private void OnDeath() //Death Functionality
    {
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
        StopCoroutine("AbductHuman");
        StartCoroutine("MoveLeftRight");
    }

    private void OnIdle() //Resets and Randomizes the move direction
    {
        StopCoroutine("MoveLeftRight");
        StopCoroutine("AbductHuman");
        StartCoroutine("IdleWaitLogic");
    }

    private void OnEscape()
    {
        StopCoroutine("MoveLeftRight");
        StopCoroutine("AbductHuman");
        StopCoroutine("IdleWaitLogic");
        StartCoroutine("Escape");
    }

    private void SpeedBoost(float xDir, float yDir)
    {
        _rgbd2.AddForce(new Vector2(xDir * _MoveSpeed * Time.deltaTime, 
                                                                     yDir * _MoveSpeed * Time.deltaTime), ForceMode2D.Impulse);
    }
    
    private void FreezeMovement()
    {
        _rgbd2.velocity = new Vector2(0, 0);
    }
    #endregion



    #region AI Logic
    private void LookForTargetBelow() //Uses a Raycast to look DOWN for a Target. This can be the Human or Player, then determines what the next state is.
    {
        rayCastDown = Physics2D.Raycast(_RayCastAimDown.position, Vector2.down);

        if (rayCastDown.collider != null) //Ensures the collider is not null
        {
            if(rayCastDown.collider.tag == "Human" && rayCastDown.collider.gameObject.GetComponent<HumanAI>().IsSaved) { return; }

            switch (rayCastDown.collider.tag) //Checks the tag of what the raycast saw then changes the current State
            {
                case "Human":
                    _currentState = States.Abduct;
                    break;

                case "Player":
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
        
        while (RandomMoveDirection == 0)
        {
            RandomMoveDirection = Random.Range(-1, 2);
        }

        _currentState = States.Patrol; //Sets state back to patrol
    }

    private IEnumerator AbductHuman()
    {
        _rgbd2.velocity = new Vector2(0, _rgbd2.velocity.y);
        SpeedBoost(0, -.15f);
        yield return new WaitForSeconds(0f);
    }

    private IEnumerator Escape()
    {
        yield return new WaitForSeconds(1.5f);
        _rgbd2.velocity = new Vector2(0, (_MoveSpeed * 3) * Vector2.up.y * Time.deltaTime);
    }


    #endregion



    private void OnDestroy() //Clean up a little bit of trash here
    {
        StopAllCoroutines();
    }
}
