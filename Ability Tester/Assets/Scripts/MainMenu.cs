using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Params
    [SerializeField] string Game;

    //Declare vars
    SceneManagement scene;

    private void Start()
    {
        scene = FindObjectOfType<SceneManagement>();
    }

    public void BackButton()
    {
        scene.LoadScene("Menu");
    }

    public void TargetTest()
    {
        scene.LoadScene("Target Test");
    }

    public void ClickTest()
    {
        scene.LoadScene("Click Test");
    }

    public void ReflexTest()
    {
        scene.LoadScene("Reflex Test");
    }

    public void VisionTest()
    {
        scene.LoadScene("Vision Test");
    }

    public void NumberTest()
    {
        scene.LoadScene("Number Test");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
