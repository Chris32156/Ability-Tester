using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetTestPlay : MonoBehaviour
{
    //Params
    [SerializeField] TextMeshProUGUI HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Update high score text
        int HighScore = PlayerPrefs.GetInt("Target Test High Score", 0);
        HighScoreText.SetText("High Score " + HighScore.ToString() + "ms Per Target");
    }

    public void buttonPress()
    {
        //Destroy UI after play button pressed
        Destroy(gameObject);
    }
}
