using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickTest : MonoBehaviour
{
    //Params
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI ClickText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] float Seconds;

    //Declare vars
    float StartingSeconds;
    float timeStarted;
    bool GameInPlay = false;
    int Clicks = 0;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManager>();

        StartingSeconds = Seconds;

        //Update UI
        HighScoreText.SetText("High Score " + PlayerPrefs.GetFloat("Click Test High Score").ToString("F1") + " Clicks Per Second");
        TimerText.SetText(StartingSeconds.ToString());
    }

    private void Update()
    {
        if (GameInPlay)
        {
            //Update timer
            Seconds = 10 - (Time.time - timeStarted);
            TimerText.SetText(Seconds.ToString("0"));

            //Game Over
            if (Seconds <= 0)
            {
                gameOver();
            }

            //Count Clicks
            if (Input.GetMouseButtonDown(0))
            {
                audio.Success();

                Clicks++;
                ClickText.SetText(Clicks.ToString());
            }
        }
    }

    public void StartGame()
    {
        audio.ButtonPress();

        //Initalize variables
        Clicks = 0;
        Seconds = StartingSeconds;
        timeStarted = Time.time;
        GameInPlay = true;

        //Update Canvas
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        StartCanvas.SetActive(false);

        //Update text
        ClickText.SetText(Clicks.ToString());
    }

    private void gameOver()
    {
        //Update canvas
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        //Stop game
        GameInPlay = false;

        //Calculate clicks per second
        float score = Clicks / (Time.time - timeStarted);

        //Check if high score
        if (score > PlayerPrefs.GetFloat("Click Test High Score", 0))
        {
            PlayerPrefs.SetFloat("Click Test High Score", score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        //Display score
        ScoreText.SetText(score.ToString("F1") + " Clicks Per Second");
    }
}
