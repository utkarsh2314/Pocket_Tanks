using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioncontrol1 : MonoBehaviour
{
    bool turn=true;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(turn)
            if(collision.gameObject.name=="player1"){
            Destroy(gameObject);
            turn=false;
            //scoring
        }
        else{
            if(collision.gameObject.name=="player2"){
            Destroy(gameObject);
            turn=true;
            //scoring
        }
        }
    }
}