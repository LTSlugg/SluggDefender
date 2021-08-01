using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAI : MonoBehaviour
{
    //Data Variables
    private Enemy _currentEnemy;
    private bool IsAbducted = false;

    private void FixedUpdate()
    {
        GetAbducted();
    }

    private void GetAbducted()
    {
        if (_currentEnemy == null ) { return; } //If Gameobject is null break out of function
            
        transform.position = _currentEnemy._RayCastAimDown.position; //Clamps position to the enemies raycast position
    }


    private void OnTriggerEnter2D(Collider2D collision) //Checks what has collided with and functions accordingly
    {
        if(collision.tag != null)
        {
            if (collision.CompareTag("Enemy"))
            {
                _currentEnemy = collision.gameObject.GetComponent<Enemy>();
            }
        }
    }
}
