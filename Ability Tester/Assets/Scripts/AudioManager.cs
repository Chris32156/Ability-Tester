using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Params
    [SerializeField] AudioClip button;
    [SerializeField] AudioClip good;
    [SerializeField] AudioClip bad;

    //Declare Vars
    AudioSource audio;

    private void Awake()
    {
        var objs = FindObjectsOfType<AudioManager>();

        //Checks If Already Spawned
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //Keeps It Loaded Even In Between Scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void MuteButtonPress()
    {
        audio.PlayOneShot(button);
    }

    public void ButtonPress()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            audio.PlayOneShot(button);
        }
    }

    public void Success()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            audio.PlayOneShot(good);
        }
    }

    public void Failure()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            audio.PlayOneShot(bad);
        }
    }
}
