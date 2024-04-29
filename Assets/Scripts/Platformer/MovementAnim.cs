using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovementAnim: MonoBehaviour
{
    // Horizontal input value
    private float horizontal;

    // Movement speed
    private float speed = 5f;

    // Jumping power
    private float jumpingPower = 12f;

    // Flag to check if the character is facing right
    private bool isFacingRight = true;

    // Flag to check if the character is grounded
    private bool isGrounded;

    // Reference to the Rigidbody2D component
    [SerializeField] private Rigidbody2D rb;

    // Spawn point for the character
    [SerializeField] public Transform spawnPoint;

    public Animator anim;

    void Update()
    {

        

        // Check for jump input and if the character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("Jump", true);
        }

        // Apply reduced jump if the jump button is released
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Flip the character if needed
        Flip();
       
    }

    private void FixedUpdate()
    {
        // Get horizontal input
        horizontal = Input.GetAxisRaw("Horizontal");
        // Move the character horizontally
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(horizontal));
        if (rb.velocity.y < 0f)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }
    }

    // Check if the character exits the ground collision
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Check if the character enters the ground collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }

        // Respawn the character if it collides with the respawn object
        if (collision.gameObject.CompareTag("Respawn"))
        {
            transform.position = spawnPoint.position;
        }
    }

    // Flip the character horizontally
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
