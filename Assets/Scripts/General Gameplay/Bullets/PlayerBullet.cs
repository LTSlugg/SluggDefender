using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Data Variables
    [SerializeField]private float _TravelVelocity = 55;
    [SerializeField] private float _DestroySelfSpeed = 2f;



    // Update is called once per frame
    void FixedUpdate()
    {
        MoveRight();
    }

    private void MoveRight()
    {
        transform.Translate(0, _TravelVelocity * Time.deltaTime, 0);

        Destroy(this.gameObject, _DestroySelfSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
