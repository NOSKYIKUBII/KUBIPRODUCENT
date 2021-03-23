using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float gravity;
    public float jumpForce;

    bool isGrounded = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        else if (collision.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.velocity = new Vector2(0f, jumpForce);
                isGrounded = false;
            }
        }

        transform.Rotate(new Vector3(0f, -10f * Time.deltaTime * 0f));

        


        rigidbody.AddForce(new Vector2(0f, gravity * Time.deltaTime));
    }



}
