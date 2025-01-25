using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;

    [Header("--------Audio clip--------")]
    public AudioClip BgMusic;
    public AudioClip[] audioList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        music.clip = BgMusic;
        music.Play();
    }

    public void PlaySFX(int i)
    {
        SFX.PlayOneShot(audioList[i]);
    }
}
