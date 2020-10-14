using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetTest : MonoBehaviour
{
    //Params
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI TargetText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] int NumberOfTargets;

    //Declare vars
    int StartingNumberOfTargets;
    float timeStarted;
    Target target;

    // Start is called before the first frame update
    void Start()
    {
        StartingNumberOfTargets = NumberOfTargets;

        //Update UI
        TargetText.SetText(StartingNumberOfTargets.ToString());
    }

    public void StartGame()
    {
        //Initilize Variables
        NumberOfTargets = StartingNumberOfTargets;
        TargetText.SetText(StartingNumberOfTargets.ToString());
        timeStarted = Time.time;

        //Update canvases
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
    }

    public void TargetHit()
    {
        //Subtract one target
        NumberOfTargets--;

        //Check if player destroyed all targets
        if (NumberOfTargets <= 0)
        {
            gameOver();
        }
        else
        {
            //Update text
            TargetText.SetText(NumberOfTargets.ToString());
        }
    }

    private void gameOver()
    {
        //Update Canvases
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        //Calculate score than round it
        float a = (Time.time - timeStarted) / StartingNumberOfTargets;
        int score = Mathf.RoundToInt(a * 1000); 

        //Check if high score
        if (score < PlayerPrefs.GetInt("Target Test High Score", 0) || PlayerPrefs.GetInt("Target Test High Score", 0) == 0)
        {
            PlayerPrefs.SetInt("Target Test High Score", score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        //Update score text
        ScoreText.SetText(score.ToString() + "ms Per Target");
    }
}
