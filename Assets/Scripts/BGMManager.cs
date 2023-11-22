using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgmMusic;

    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
       source = GetComponent<AudioSource>();

       source.clip = bgmMusic; 
       source.Play(); 
    }

    public void StopBGM()
    {
        source.Stop();
    }
}
