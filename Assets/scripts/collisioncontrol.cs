using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioncontrol : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="tank2")
        Destroy(gameObject);
    }
}