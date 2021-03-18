using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float gravity;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Rotate(new Vector3(0f, -10f * Time.deltaTime * 0f));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(0f, jumpForce);
        }


        rigidbody.AddForce(new Vector2(0f, gravity * Time.deltaTime));
    }



}
