using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Data Variables
    [SerializeField]private float travelVel = 15;
    [SerializeField]private float destroySelfTimer = 4f;

    public float moveDirection;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, travelVel * moveDirection * Time.deltaTime, 0);

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
