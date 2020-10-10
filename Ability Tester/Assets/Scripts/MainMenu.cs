using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Params
    [SerializeField] string Game;

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

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
