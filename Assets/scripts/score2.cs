using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class score2 : MonoBehaviour
{
    
    public static int scoreof1 =0;
    public TMP_Text Score;
    public int collideon=0;
    
    void EnableCollider()
    {
        collideon=1;
    }



    void OnCollisionEnter2D (Collision2D col )
    {
        if(col.gameObject.tag.Equals("bomb") )
        {
            scoreof1+=10;
            Score.text ="SCORE: " + scoreof1;
            Destroy(col.gameObject);
        }
    }
}
