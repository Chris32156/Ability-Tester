using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberTest : MonoBehaviour
{
    //Params
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject NumberCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI GameScoreText;
    [SerializeField] TextMeshProUGUI NumberText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] GameObject InputField;

    //Declare vars
    int Score = 0;
    string Answer;
    float timeStarted = 0;
    bool inPlay;

    // Start is called before the first frame update
    void Start()
    {
        //Set high score text
        HighScoreText.SetText("High Score " + PlayerPrefs.GetInt("Number Test High Score").ToString() + " Numbers Correct");
    }

    private void Update()
    {
        //Enter press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }

        if (inPlay && Time.time > timeStarted + 3)
        {
            NumberCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            inPlay = false;
        }
    }

    public void StartGame()
    {
        //Reset score
        Score = 0;
        inPlay = true;
        timeStarted = Time.time;

        SetNumber();

        //Update UI
        NumberCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        StartCanvas.SetActive(false);
        GameScoreText.SetText(Score.ToString());
    }

    public void SetNumber()
    {
        //Reset string 
        Answer = Random.Range(0, 10).ToString();

        //Set answer
        for (int i = 0; i < Score; i++)
        {
            int index = Random.Range(0, 10);
            Answer += index.ToString();
        }

        //Set letter text
        NumberText.SetText(Answer);
    }

    public void CheckAnswer()
    {
        string input = InputField.GetComponent<TextMeshProUGUI>().text;

        Debug.Log(input + Answer);

        //Compare Ans
        if (input.Contains(Answer))
        {
            //Update Score
            Score++;
            GameScoreText.SetText(Score.ToString());

            //Reset Number
            SetNumber();

            //Set canvases
            NumberCanvas.SetActive(true);
            GameCanvas.SetActive(false);

            //Update Vars
            timeStarted = Time.time;
            inPlay = true;
        }
        else
        {
            //If Wrong
            gameOver();
        }
    }

    private void gameOver()
    {
        //Update UI
        GameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);

        //Update High Score
        if (Score > PlayerPrefs.GetInt("Number Test High Score", 0))
        {
            PlayerPrefs.SetInt("Number Test High Score", Score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        //Update Score
        ScoreText.SetText(Score.ToString() + " Numbers Correct");
    }
}
