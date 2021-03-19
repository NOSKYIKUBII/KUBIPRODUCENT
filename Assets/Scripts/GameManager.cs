using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float worldScrollingSpeed;

    public GameObject cloud;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Clouds", 3, 2);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        worldScrollingSpeed += Time.deltaTime * Time.deltaTime;
        
    }



    void Clouds()
    {
        Vector3 cloudPosition = new Vector3(10.21f, Random.Range(-0.01f, 3.54f), 0f);

        Instantiate(cloud, cloudPosition, Quaternion.identity);
    }


}
