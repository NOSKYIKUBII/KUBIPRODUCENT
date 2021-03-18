using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public GameObject floorTile1;      //lewy
    public GameObject floorTile2;      //prawy

    public GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floorTile1.transform.position -= new Vector3(10f * Time.deltaTime, 0f, 0f);
        floorTile2.transform.position -= new Vector3(10f * Time.deltaTime, 0f, 0f);

        if (floorTile2.transform.position.x < -1f)
        {
            floorTile1.transform.position += new Vector3(34.52f, 0f, 0f);

            var newTile = Instantiate(Tile, floorTile2.transform.position + new Vector3(14.12f, 0, 0), Quaternion.identity);

            Destroy(floorTile1);

            floorTile1 = floorTile2;
            floorTile2 = newTile;
            
        }
    }
}
