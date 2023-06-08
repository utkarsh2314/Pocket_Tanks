using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class playeraim1 : MonoBehaviour
{
    public int MinPower = 0;
    public int MaxPower = 100;

    int curPower;
    int curAngle;

    public SpriteRenderer AimSprite;
    public TMP_Text powerLbl;
    public TMP_Text AngleLbl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButton(0))
        {
            CalculateAngle();
            CalculatePower();
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
    }

    void CalculateAngle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        Vector3 dir = mousePos -transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;

        UpdateAngle((int)angle);
    }

    void UpdateAngle(int angle)
    {
        curAngle = angle;
        AimSprite.transform.rotation = Quaternion.AngleAxis (curAngle,Vector3.forward);

        if(curAngle<0)
        {
            curAngle+=360;
        }
        AngleLbl.text ="ANGLE: " + curAngle;

    }

    void CalculatePower()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z=0;

        float distance = Vector3.Distance(mousePos, transform.position);
        UpdatePower((int)distance *10);
        
        
    }

    void UpdatePower(int amount)
    {
        curPower = Mathf.Clamp(amount,MinPower ,MaxPower);

        powerLbl.text ="POWER: " + curPower;
    }



}
