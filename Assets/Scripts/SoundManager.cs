using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}

    AudioSource _sfxAudio;
    [SerializeField]private AudioClip deathSound;
    [SerializeField]private AudioClip jumpSound;
    [SerializeField]private AudioClip bgmMusic;
    [SerializeField]private AudioClip estrellitaSFX;
    
    // Start is called before the first frame update
    void Awake()
    {
        _sfxAudio = GetComponent<AudioSource>();
        
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathSound()
    {
        _sfxAudio.PlayOneShot(deathSound);
    }

    public void JumpSound()
    {
        _sfxAudio.PlayOneShot(jumpSound);
    }

    public void StarColeccion()
    {
        _sfxAudio.PlayOneShot(estrellitaSFX);
    }
}
