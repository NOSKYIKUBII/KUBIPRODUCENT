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
    public float highestScore;
    public float tempworldScrollingSpeed;

    public GameObject cloud;
    public GameObject BuffText;
    public GameObject pauseMenu;

    public Text ScoreText;

    public bool isPaused = false;
    

    // Start is called before the first frame update
    void Start()
    {
        highestScore = PlayerPrefs.GetFloat("PlayerScore");

        BuffText.SetActive(false);
        InvokeRepeating("Clouds", 3, Random.Range(2.5f, 4f));

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void FixedUpdate()
    {
        worldScrollingSpeed += 0.000005f;
        score += worldScrollingSpeed;
        ScoreText.text = score.ToString("0");

        






        if (highestScore < score)
        {
            PlayerPrefs.SetFloat("PlayerScore", score);
            PlayerPrefs.Save();
        }
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
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        MusicManager.instance.Click();
    }

    public void Pause()
    {
        tempworldScrollingSpeed = worldScrollingSpeed;
        worldScrollingSpeed = 0f;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        MusicManager.instance.Click();
        worldScrollingSpeed = tempworldScrollingSpeed;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
