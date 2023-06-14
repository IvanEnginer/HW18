using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerMove : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public float JumpSpeed;

    public bool Grounded;

    public SpriteRenderer SpriteRenderer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Rigidbody2D.velocity += new Vector2(0f, JumpSpeed);
            }
        }

        if (Rigidbody2D.velocity.x > 0f)
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
        else if (Rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Rigidbody2D.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float dot = Vector2.Dot(collision.contacts[0].normal, Vector2.up);

        if (dot > 0.5f)
        {
            Grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }
}
