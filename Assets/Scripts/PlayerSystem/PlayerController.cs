using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GeneralControlsScript _inputActions;
    Rigidbody2D _rgbd2;

    // Data Variables
    [SerializeField] private float _PlayerMoveSpeed = 350;
    [SerializeField] private Transform _BulletSpawnTransform; //Where to spawn the 
    [SerializeField] private GameObject _PlayerDefaultBullet; //The default bullet game object
    [SerializeField] private GameObject _PlayerDefaultNuke; //The default nuke game object 
    [SerializeField] public Transform _PlayerCarryTransform; //The transform location for the player to carry objects

    // Input Variables
    Vector2 _playerMoveDirection;
    KeyCode _playerKeyCode;


    private void Awake()
    {
        _inputActions = new GeneralControlsScript();
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.GeneralControls.Move.performed += ctx => OnMovement(ctx.ReadValue<Vector2>());
        _inputActions.GeneralControls.Move.canceled += ctx => OnMovement(ctx.ReadValue<Vector2>());

        _inputActions.GeneralControls.Fire.performed += ctx => PlayerFire();
        _inputActions.GeneralControls.Nuke.performed += ctx => PlayerNuke();
    }


    private void OnDisable()
    {
        _inputActions.Disable();   
    }

    // Start is called before the first frame update
    void Start()
    {
        _rgbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
    }




    // Front Door Logic
    private void PlayerMove()
    {
        _rgbd2.velocity = new Vector2(_PlayerMoveSpeed * _playerMoveDirection.x * Time.deltaTime,
                                                                                                 _PlayerMoveSpeed * _playerMoveDirection.y * Time.deltaTime);
    }


    // Back Door Logic
    private void PlayerFire() //Spawns a bullet when the Fire Action Event is Called
    {
        Instantiate<GameObject>(_PlayerDefaultBullet, _BulletSpawnTransform.position, Quaternion.Euler(0, 0, -90)); //Spawns the Default bullet at a location rotated -90 degrees on z axis
    }

    private void PlayerNuke() //Spawns a nuke that clears the screen when the Fire Action Event is Called
    {
        Instantiate<GameObject>(_PlayerDefaultNuke, this.transform.position, Quaternion.identity); //Spawns the Default Nuke at this location
    }

    private void PlayerDead() //TODO: Finish this function
    {
        Destroy(this.gameObject);
    }




    // Input Events
    private void OnMovement(Vector2 ctxMoveDir)
    {
        _playerMoveDirection = ctxMoveDir;
    }

    //Tracking Logic
    public Vector2 PlayerLocation()
    {
        return transform.position;
    }

    //Collision Logic
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet"))
        { 
            Debug.Log("Has Hit Enemy"); 
        }

        if(collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        //TODO: DO A CALL TO HEALTH SYSTEM TO SEE IF PLAYER IS DEAD AND FINISH THIS FUNCTIONALITY
    }
}
