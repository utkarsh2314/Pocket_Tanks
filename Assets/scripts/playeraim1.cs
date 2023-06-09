using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class playeraim1 : MonoBehaviour
{
    public int MinPower = 0;
    public int MaxPower = 100;

    int curPower1;
    int curAngle1;

    public SpriteRenderer AimSprite1;
    public TMP_Text powerLbl1;
    public TMP_Text AngleLbl1;


    int curPower2;
    int curAngle2;

    public SpriteRenderer AimSprite2;
    public TMP_Text powerLbl2;
    public TMP_Text AngleLbl2;

    
    public GameObject ProjectilePrefab;
    public Transform Muzzle1;
    public Transform Muzzle2;
    
    
    public bool turn1=true;
    
    public void FireProjectile(int power)
{
    GameObject insProj;
    if (turn1)
        insProj = Instantiate(ProjectilePrefab, Muzzle1.transform.position, Muzzle1.transform.rotation);
    else
        insProj = Instantiate(ProjectilePrefab, Muzzle2.transform.position, Muzzle2.transform.rotation);

    insProj.GetComponent<projectile1>().Initialize(power);
}



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(!turn1)
        {
            if( Input.GetMouseButton(0))
        {
            CalculateAngle2();
            CalculatePower2();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FireProjectile(curPower2);
            turn1=true;
        }
        }
        else
        {
        if( Input.GetMouseButton(0))
        {
            CalculateAngle1();
            CalculatePower1();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FireProjectile(curPower1);
            turn1=false;
        }
        }
    }

    void CalculateAngle1()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        Vector3 dir = mousePos -transform.position;
        float angle = Mathf.Atan2(dir.y ,dir.x)*Mathf.Rad2Deg;

        UpdateAngle1((int)angle);
    }

    void UpdateAngle1(int angle)
    {
        curAngle1 = angle;
        if(curAngle1<0)
        {
            curAngle1+=360;
        }
        
        AimSprite1.transform.rotation = Quaternion.AngleAxis (curAngle1,Vector3.forward);

        AngleLbl1.text ="ANGLE: " + curAngle1;

    }

    void CalculatePower1()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        float distance = Vector3.Distance(mousePos, transform.position);
        UpdatePower1((int)distance *10);
        
        
    }

    void UpdatePower1(int amount)
    {
        curPower1 = Mathf.Clamp(amount,MinPower ,MaxPower);

        powerLbl1.text ="POWER: " + curPower1;
    }


    
    void CalculateAngle2()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        Vector3 dir = mousePos -transform.position;
        float angle = Mathf.Atan2(dir.y ,dir.x)*Mathf.Rad2Deg;

        UpdateAngle2((int)angle);
    }

    void UpdateAngle2(int angle)
    {
        curAngle2 = angle;
        if(curAngle2<0)
        {
            curAngle2+=360;
        }
        
        AimSprite2.transform.rotation = Quaternion.AngleAxis (curAngle2,Vector3.forward);

        AngleLbl2.text ="ANGLE: " + curAngle2;

    }

    void CalculatePower2()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        float distance = Vector3.Distance(mousePos, transform.position);
        UpdatePower2((int)distance *10);
        
        
    }

    void UpdatePower2(int amount)
    {
        curPower2 = Mathf.Clamp(amount,MinPower ,MaxPower);

        powerLbl2.text ="POWER: " + curPower2;
    }

}
