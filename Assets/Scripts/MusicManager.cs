using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip clickAudio;
    public AudioClip jumpAudio;
    


    public AudioSource effectsSource;
    

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(effectsSource.gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        audioSource.PlayOneShot(clickAudio, 1f);
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jumpAudio, 1f);
    }
    
}
