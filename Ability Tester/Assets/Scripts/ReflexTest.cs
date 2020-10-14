using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReflexTest : MonoBehaviour
{
    //Params
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] GameObject star;
    [SerializeField] float MinSeconds;
    [SerializeField] float MaxSeconds;
    
    //Declare vars
    float timeStarted;
    float ReflexTime;
    float TimeUntilGreen;
    int score;
    bool GameInPlay = false;
    bool ReflexStarted;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManager>();

        //Update UI
        HighScoreText.SetText("High Score " + PlayerPrefs.GetInt("Reflex Test High Score").ToString() + "ms");
    }

    private void Update()
    {
        if (GameInPlay)
        {
            //If timer is up
            if(Time.time > timeStarted + TimeUntilGreen && !ReflexStarted)
            {
                //Update Var
                ReflexTime = Time.time;
                ReflexStarted = true;

                //Set star green
                star.GetComponent<Image>().color = new Color32(48, 217, 59, 255);
            }

            //Player reflex
            if(Input.GetMouseButtonDown(0) && ReflexStarted)
            {
                audio.Success();

                //Get Score
                float a = Time.time - ReflexTime;
                Debug.Log(a);
                score = Mathf.RoundToInt(a * 1000);

                gameOver();
            }
            if (Input.GetMouseButtonDown(0) && !ReflexStarted)
            {
                audio.Failure();
            }
        }
    }

    public void StartGame()
    {
        audio.ButtonPress();

        //Initalize variables
        timeStarted = Time.time;
        ReflexStarted = false;
        TimeUntilGreen = Random.Range(MinSeconds, MaxSeconds);
        GameInPlay = true;

        //Set star Red
        star.GetComponent<Image>().color = new Color32(229, 29, 29, 255);

        //Update Canvas
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        StartCanvas.SetActive(false);
    }

    private void gameOver()
    {
        //Update canvas
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        //Stop game
        GameInPlay = false;

        //Check if high score
        if (score < PlayerPrefs.GetInt("Reflex Test High Score", 0) || PlayerPrefs.GetInt("Reflex Test High Score", 0) == 0)
        {
            PlayerPrefs.SetInt("Reflex Test High Score", score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        //Display score
        ScoreText.SetText(score.ToString() + "ms");
    }
}
