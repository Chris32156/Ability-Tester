using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Declare vars
    SceneManagement scene;
    AudioManager audio;

    private void Start()
    {
        scene = FindObjectOfType<SceneManagement>();
        audio = FindObjectOfType<AudioManager>();
    }

    //Buttons
    public void BackButton()
    {
        scene.LoadScene("Menu");
        audio.ButtonPress();
    }

    public void TargetTest()
    {
        scene.LoadScene("Target Test");
        audio.ButtonPress();
    }

    public void ClickTest()
    {
        scene.LoadScene("Click Test");
        audio.ButtonPress();
    }

    public void ReflexTest()
    {
        scene.LoadScene("Reflex Test");
        audio.ButtonPress();
    }

    public void VisionTest()
    {
        scene.LoadScene("Vision Test");
        audio.ButtonPress();
    }

    public void NumberTest()
    {
        scene.LoadScene("Number Test");
        audio.ButtonPress();
    }

    public void ResetHighScore()
    {
        int a = PlayerPrefs.GetInt("Muted", 0);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Muted", a);

        audio.ButtonPress();
    }
}
