using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_moviment : MonoBehaviour{

    public float speed;
    public float jumpingPower = 16f;
    public Animator anim;
    
    public bool isFacingRight = true;
    public bool isFacingRight1 = true;

    private float horizontal;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if (Input.GetButtonDown("Jump")&& isGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));

       
    }
    
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {    
            isFacingRight = !isFacingRight; 
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        
            isFacingRight1 = false;
        }
    }
}
