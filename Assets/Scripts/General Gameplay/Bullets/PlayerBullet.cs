using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Data Variables
    [SerializeField]private float travelVel = 15;
    [SerializeField] private float destroySelfTimer = 4f;

    float moveDirection = 1f;

    public PlayerBullet(float moveDirection)
    {
        this.moveDirection = moveDirection;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, travelVel * Time.deltaTime, 0);

        Destroy(this.gameObject, destroySelfTimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
