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

        Invoke("Explode",AliveTime);
        Invoke("EnableCollider",0f);

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tank1"))
        {
            // Handle collision with objects having "MyTag" tag
        }

        // Access the GameObject collided with
        GameObject collidedObject = collision.gameObject;
        // Access the Rigidbody of the collided object
        Rigidbody collidedRigidbody = collidedObject.GetComponent<Rigidbody>();
        // Access other components or properties of the collided object

        // Perform actions based on the collision
        // For example, destroy the collided object
        Destroy(collidedObject);
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
