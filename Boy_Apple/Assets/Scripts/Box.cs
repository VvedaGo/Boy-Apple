using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    bool on;
    int timer=3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            on = true;
        }
    }
    private void FixedUpdate()
    {
        if (on)
        {
            timer--;
            if(timer==0)
            Destroy(gameObject);
        }
    }


}
