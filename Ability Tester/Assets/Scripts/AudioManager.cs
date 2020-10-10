using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

    public void ButtonPress()
    {

    }
}
