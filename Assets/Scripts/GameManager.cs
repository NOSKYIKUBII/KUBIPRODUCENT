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
    public float timeSlowTime;
    public float timeLeft;
    public float cantJumpTime;
    public float immortalTime;

    public GameObject cloud;
    public GameObject BuffText;
    public GameObject pauseMenu;
    public GameObject luckyBox;
    public GameObject DeathMenu;

    public Text ScoreText;
    public Text buffTimeText;
    public Text buffType;

    public bool isPaused;
    public bool isSlow;
    public bool cantJump;
    public bool isDead;
    public bool cantDie;


    // Start is called before the first frame update
    void Start()
    {
        highestScore = PlayerPrefs.GetFloat("PlayerScore");

        //BuffText.SetActive(false);
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
        if (IsInvoking("CancelSlow"))
        {
            timeLeft -= Time.deltaTime;
        }
        else if (IsInvoking("CancelJump") || IsInvoking("CancelImmortal"))
        {
            timeLeft -= 0.1f * Time.deltaTime;
        }

        buffTimeText.text = timeLeft.ToString("0");

        if (!isDead)
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
            if (IsInvoking("CancelSlow") || IsInvoking("CancelJump") || IsInvoking("CancelImmortal"))
            {
                BuffText.SetActive(true);
            }
            else if (!IsInvoking("CancelSlow") || !IsInvoking("CancelJump") || !IsInvoking("CancelImmortal"))
            {
                BuffText.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            worldScrollingSpeed += 0.000005f;
            score += worldScrollingSpeed;
            ScoreText.text = score.ToString("0");
        }


        timeLeft -= Time.deltaTime;




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

    public void TimeSlow()
    {
        if (isSlow)
        {
            CancelInvoke("CancelSlow");
        }
        else
        {
            Time.timeScale = 0.5f;
            isSlow = true;
            Invoke("CancelSlow", timeSlowTime);
            timeLeft = timeSlowTime * 2;
            buffType.text = "SPOWOLNIENIE";
        }

    }

    private void CancelSlow()
    {
        Time.timeScale = 1f;
        isSlow = false;
        Debug.Log("SLOW STOP");

    }

    public void CanNotJump()
    {
        cantJump = true;
        Invoke("CancelJump", cantJumpTime);
        timeLeft = cantJumpTime;
        buffType.text = "NIE MOZESZ SKAKAC!";
    }

    private void CancelJump()
    {
        cantJump = false;
    }

    public void Immortal()
    {
        cantDie = true;
        Invoke("CancelImmortal", immortalTime);
        timeLeft = immortalTime;
        buffType.text = "NIESMIERTELNOSC";

    }

    private void CancelImmortal()
    {
        cantDie = false;
    }

    public void Death()
    {
        Debug.Log("MARTWY");
        isDead = true;
        worldScrollingSpeed = 0f;
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
    }

    public void Respawn()
    {
        SceneManager.LoadScene(1);
        isDead = false;
        Time.timeScale = 1f;
    }
}
