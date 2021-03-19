using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(2f * GameManager.instance.worldScrollingSpeed * Time.deltaTime, 0f);

        if (transform.position.x < -11.11)
        {
            Destroy(gameObject);
        }
    }
}
