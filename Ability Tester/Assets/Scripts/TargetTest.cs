using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetTest : MonoBehaviour
{
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI TargetText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] int NumberOfTargets;

    int StartingNumberOfTargets;
    float timeStarted;
    Target target;
    // Start is called before the first frame update
    void Start()
    {
        StartingNumberOfTargets = NumberOfTargets;

        TargetText.SetText(StartingNumberOfTargets.ToString());
    }

    public void StartGame()
    {
        NumberOfTargets = StartingNumberOfTargets;
        timeStarted = Time.time;
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
    }

    public void TargetHit()
    {
        NumberOfTargets--;
        if (NumberOfTargets <= 0)
        {
            gameOver();
        }
        else
        {
            TargetText.SetText(NumberOfTargets.ToString());
        }
    }

    private void gameOver()
    {
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        float a = (Time.time - timeStarted) / StartingNumberOfTargets;
        int score = Mathf.RoundToInt(a * 1000); 
        if (score < PlayerPrefs.GetInt("Target Test High Score", 0) || PlayerPrefs.GetInt("Target Test High Score", 0) == 0)
        {
            PlayerPrefs.SetInt("Target Test High Score", score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        ScoreText.SetText(score.ToString() + "ms Per Target");
    }
}
