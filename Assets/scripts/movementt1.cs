using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementt1 : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    private bool isFacingRight= false;

    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip(); 
    }
    private void FixedUpdate()
    {
        rb.velocity= new Vector2(horizontal*speed , rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal <0f|| !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale =transform.localScale;
            localScale.x *=-1f;
            transform.localScale = localScale;
        }
    }
}
