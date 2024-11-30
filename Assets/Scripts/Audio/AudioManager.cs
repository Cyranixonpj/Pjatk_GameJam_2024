using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header("-----------AUDIO SOURCES-----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("-----------AUDIO CLIPS-----------")]
    public AudioClip backgroundMusic;
    public AudioClip death;
    public AudioClip Shoot;
    public AudioClip EnemyShoot;
    public AudioClip Hit;
    public AudioClip Walk;
    
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
