using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot1 : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform Muzzle;
    
    public void FireProjectile(int power)
    {
        GameObject insProj = Instantiate(ProjectilePrefab, Muzzle.transform.position,Muzzle.transform.rotation);
        insProj.GetComponent<projectile1>().Initialize(power);
    }
}
