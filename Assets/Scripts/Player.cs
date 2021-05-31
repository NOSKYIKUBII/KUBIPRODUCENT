using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //COLUMBUS 2D
    //ROBINSON
    //NEMO
    //KET
    //PYTEASH
    //Marcus / Marko
    //Mercurius
    //THE LONG WAY


    // NIESMIERTELNOSC
    // SPOWOLNIENIE CZASU
    // +500 pkt
    // -400pkt
    // BLOKADA SKAKANIA

    int[] buffy = new int[22] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21};

    Rigidbody2D rigidbody;


    public float gravity;
    public float jumpForce;


    public bool isGrounded;
    public bool doubleJump;



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
        else if (collision.CompareTag("Box"))
        {
            //Random.Range(0, 19)
            Destroy(collision.gameObject);
            int rand = buffy[Random.Range(0, 21)];

            Debug.Log(rand);

            if (rand == 2 || rand == 0 || rand == 1 || rand == 7 || rand == 8 || rand == 13 || rand == 14 || rand == 15)
            {
                GameManager.instance.TimeSlow();
            }
            else if (rand == 3 || rand == 9 || rand == 10 || rand == 17)
            {
                GameManager.instance.score += 100;
                GameManager.instance.buffTimeText.text = "";
                GameManager.instance.timeLeft = 2;
                GameManager.instance.buffType.text = "+100";
                if (GameManager.instance.timeLeft >= 0 && !IsInvoking("CancelSlow") && !IsInvoking("CancelJump"))
                {
                    GameManager.instance.BuffText.SetActive(true);
                }
                else if (GameManager.instance.timeLeft < 0)
                {
                    GameManager.instance.BuffText.SetActive(false);
                }
            }
            else if (rand == 4 || rand == 6 || rand == 12 || rand == 16 || rand == 19)
            {
                GameManager.instance.buffTimeText.text = "";
                GameManager.instance.timeLeft = 2;
                GameManager.instance.score -= 100;
                GameManager.instance.buffType.text = "-100";
                if (GameManager.instance.timeLeft >= 0 && !IsInvoking("CancelSlow") && !IsInvoking("CancelJump"))
                {
                    GameManager.instance.BuffText.SetActive(true);
                }
                else if (GameManager.instance.timeLeft < 0)
                {
                    GameManager.instance.BuffText.SetActive(false);
                }

                if (GameManager.instance.score < 0)
                {
                    GameManager.instance.score = 0;
                }
            }
            else if (rand == 5 || rand == 11 || rand == 18)
            {
                GameManager.instance.CanNotJump();
            }
            else if (rand == 20 || rand == 21)
            {
                GameManager.instance.Immortal();
            }

        }
        else if (collision.CompareTag("Spike"))
        {
            if (!GameManager.instance.cantDie)
            {
                GameManager.instance.Death();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (isGrounded)


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.instance.cantJump && isGrounded)
            {
                doubleJump = true;
                rigidbody.velocity = new Vector2(0f, jumpForce);
                isGrounded = false;
                MusicManager.instance.Jump();

            }
            else if (doubleJump)
            {
                doubleJump = false;
                rigidbody.velocity = new Vector2(0f, jumpForce);
                MusicManager.instance.Jump();

            }
        }


    }

    void FixedUpdate()
    {
        if(isGrounded)
        {
            doubleJump = false;
        }

        


        transform.Rotate(new Vector3(0f, -10f * Time.deltaTime * 0f));

        


        rigidbody.AddForce(new Vector2(0f, gravity * Time.deltaTime));
    }



}
