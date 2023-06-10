using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class score1 : MonoBehaviour
{
    
    public static int scoreof2 =0;
    public TMP_Text Score;
    public int collideon=0;
    public gamewin GameWin;

    
    void EnableCollider()
    {
        collideon=1;
    }
    


    void OnCollisionEnter2D (Collision2D col)
    {
        
        if(col.gameObject.tag.Equals("bomb"))
        {
            scoreof2+=10;
            
            Score.text ="SCORE: " + scoreof2;
            Destroy(col.gameObject);
            if(scoreof2>=100){
                GameWin.Setup(2);
            }
        }
    }
}
