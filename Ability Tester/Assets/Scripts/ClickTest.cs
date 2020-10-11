using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickTest : MonoBehaviour
{
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI ClickText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] float Seconds;

    float StartingSeconds;
    float timeStarted;
    bool GameInPlay = false;
    int Clicks = 0;
    Target target;

    // Start is called before the first frame update
    void Start()
    {
        StartingSeconds = Seconds;

        HighScoreText.SetText("High Score " + PlayerPrefs.GetFloat("Click Test High Score") + " Clicks Per Second");
        TimerText.SetText(StartingSeconds.ToString());
    }

    private void Update()
    {
        if (GameInPlay)
        {
            Seconds = 10 - (Time.time - timeStarted);
            TimerText.SetText(Seconds.ToString("0"));

            if (Seconds <= 0)
            {
                gameOver();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Clicks++;
                ClickText.SetText(Clicks.ToString());
            }
        }
    }

    public void StartGame()
    {
        Clicks = 0;
        Seconds = StartingSeconds;
        timeStarted = Time.time;

        GameInPlay = true;
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        StartCanvas.SetActive(false);

        ClickText.SetText(Clicks.ToString());
    }

    private void gameOver()
    {
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        GameInPlay = false;

        float score = Clicks / (Time.time - timeStarted);
        if (score > PlayerPrefs.GetFloat("Click Test High Score", 0))
        {
            PlayerPrefs.SetFloat("Click Test High Score", score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        ScoreText.SetText(score.ToString("F1") + " Clicks Per Second");
    }
}
