using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisionTest : MonoBehaviour
{
    //Params
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI GameScoreText;
    [SerializeField] TextMeshProUGUI LetterText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI NewRecordText;
    [SerializeField] GameObject InputField;

    //Declare vars
    int Score = 0;
    string Answer;
    float StartingFontSize;

    // Start is called before the first frame update
    void Start()
    {
        //Set high score text
        HighScoreText.SetText("High Score " + PlayerPrefs.GetInt("Vision Test High Score").ToString() + " Letters Correct");

        StartingFontSize = LetterText.fontSize;
    }

    private void Update()
    {
        //Enter press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    public void StartGame()
    {
        //Reset score
        Score = 0;

        //Update UI
        GameCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        StartCanvas.SetActive(false);
        GameScoreText.SetText(Score.ToString());
        LetterText.fontSize = StartingFontSize;

        SetLetter();
    }

    public void SetLetter()
    {
        int index = Random.Range(0, 27);

        //Convert number to letter
        switch (index)
        {
            case 1:
                Answer = "a";
                break;
            case 2:
                Answer = "b";
                break;
            case 3:
                Answer = "c";
                break;
            case 4:
                Answer = "d";
                break;
            case 5:
                Answer = "e";
                break;
            case 6:
                Answer = "f";
                break;
            case 7:
                Answer = "g";
                break;
            case 8:
                Answer = "h";
                break;
            case 9:
                Answer = "i";
                break;
            case 10:
                Answer = "j";
                break;
            case 11:
                Answer = "k";
                break;
            case 12:
                Answer = "l";
                break;
            case 13:
                Answer = "m";
                break;
            case 14:
                Answer = "n";
                break;
            case 15:
                Answer = "o";
                break;
            case 16:
                Answer = "p";
                break;
            case 17:
                Answer = "q";
                break;
            case 18:
                Answer = "r";
                break;
            case 19:
                Answer = "s";
                break;
            case 20:
                Answer = "t";
                break;
            case 21:
                Answer = "u";
                break;
            case 22:
                Answer = "v";
                break;
            case 23:
                Answer = "w";
                break;
            case 24:
                Answer = "x";
                break;
            case 25:
                Answer = "y";
                break;
            case 26:
                Answer = "z";
                break;
            default:
                Answer = "a";
                break;
        }

        //Set letter text
        LetterText.SetText(Answer);
    }

    public void CheckAnswer()
    {
        string input = InputField.GetComponent<TextMeshProUGUI>().text;

        Debug.Log(input.Contains(Answer));
        Debug.Log(input + Answer);
        Debug.Log(Answer + input);
        //Compare Ans
        if (input.Contains(Answer))
        {
            SetLetter();

            //Update Letter size
            LetterText.fontSize = LetterText.fontSize * 0.9f;

            //Update Score
            Score++;
            GameScoreText.SetText(Score.ToString());
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
        if (Score > PlayerPrefs.GetInt("Vision Test High Score", 0))
        {
            PlayerPrefs.SetInt("Vision Test High Score", Score);
            NewRecordText.SetText("New Record!");
        }
        else
        {
            NewRecordText.SetText("");
        }

        //Update Score
        ScoreText.SetText(Score.ToString() + " Letters Correct");
    }
}
