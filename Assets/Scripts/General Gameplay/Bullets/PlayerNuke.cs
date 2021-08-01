using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNuke : MonoBehaviour
{
    [SerializeField] float _ExplosionBlastIncreaseRate = 20f;
    [SerializeField] float _DestroyObjectDelay = 1f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ExplosionIncreaseRadius();
    }

    private void ExplosionIncreaseRadius() //Increases the scale of the nuke until it destroys itself
    {
        transform.localScale = new Vector2(transform.localScale.x + _ExplosionBlastIncreaseRate * Time.deltaTime,
                                                                                                                transform.localScale.y + _ExplosionBlastIncreaseRate * Time.deltaTime);

        Destroy(this.gameObject, _DestroyObjectDelay); //Destroys itself after a timer
    }
}
