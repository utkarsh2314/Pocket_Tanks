using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    Rigidbody2D rb;

    public float AliveTime =4;
    public float Radius = 2;
    public GameObject ExplosionPrefab;
    
    

    void Awake()
    {
        rb =GetComponent<Rigidbody2D>();
        
        GetComponent<Collider2D>().enabled =false;
        Invoke("Explode",AliveTime);
        Invoke("EnableCollider",0.2f);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power/4), ForceMode2D.Impulse);

    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled =true;
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
