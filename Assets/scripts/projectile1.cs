using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    Rigidbody2D rb;

    public float AliveTime =3;
    public float Radius = 2;
    public GameObject ExplosionPrefab;
    
    void Awake()
    {
        rb =GetComponent<Rigidbody2D>();

        Invoke("Explode",AliveTime);
        Invoke("EnableCollider", .2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power/2), ForceMode2D.Impulse);

    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled =true;
    }

    void Explode()
    {
        //SpawnExplosionFx();
        Destroy(gameObject);
    }
    void SpawnExplosionFx()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}
