using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalImpulse;
    float speedX;
    bool isGrounded;
    bool isRight = true;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
            anim.SetBool("isWalking", true);
            anim.speed = 1;

            if (isRight == true)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = false;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            anim.SetBool("isWalking", true);
            anim.speed = 1;

            if (isRight == false)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("isWalking", false);
            anim.speed = 100;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isWalking", false);
            anim.speed = 100;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }

        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
