using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject DeleteBtn;

    public Text HighestScore;


    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
           HighestScore.text = PlayerPrefs.GetFloat("PlayerScore").ToString("0");
        }
        //MusicManager.instance.Music();
    }

    private void FixedUpdate()
    {
        if (float.Parse(HighestScore.text) == 0f)
        {
            DeleteBtn.SetActive(false);
        }
        else
        {
            DeleteBtn.SetActive(true);
        }
    }

    public void Quit()
    {
        MusicManager.instance.Click();
        Application.Quit();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        HighestScore.text = PlayerPrefs.GetFloat("PlayerScore").ToString("0");
        MusicManager.instance.Click();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        MusicManager.instance.Click();
    }

    public void FullScreen (bool fs)
    {
        Screen.fullScreen = fs;
    }
}
