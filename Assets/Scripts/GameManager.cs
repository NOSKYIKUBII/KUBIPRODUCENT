using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float worldScrollingSpeed;
    public float score;

    public GameObject cloud;
    public GameObject BuffText;

    public Text ScoreText;

    public bool Paused = false;
    

    // Start is called before the first frame update
    void Start()
    {
        BuffText.SetActive(false);
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
        worldScrollingSpeed += 0.000005f;
        score += worldScrollingSpeed;
        ScoreText.text = score.ToString("0");

        if(Input.GetKeyDown(KeyCode.Escape) && Paused == false)
        {
            Time.timeScale = 0;
            Paused = true;
        }
        /*
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused)
        {
            Time.timeScale = 1;
            Paused = false;
        }
        */
    }



    public void Clouds()
    {
        Vector3 cloudPosition = new Vector3(10.21f, Random.Range(-0.01f, 3.54f), 0f);

        Instantiate(cloud, cloudPosition, Quaternion.identity);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("CLICK");
    }
}
