using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Vector3 SpawnValues;
    [Header("Text")]
    public Text ScoreText;
    public Text GameOverText;
    public Text ReStartText;
    int ScoreTotal;
    bool reStart;
    bool gameOver;



    void Start ()
    {
        ScoreTotal = 0;
        UpdateScore();
        GameOverText.text = "";
        ReStartText.text = "";
        reStart = false;
        gameOver = false;
    }

    void Update()
    {
        if(reStart)
        {
            if (Input.GetKeyDown(KeyCode.R))
                Application.LoadLevel(Application.loadedLevel);
        }
        
    }
  
    public void AddScore(int ScoreNumber)
    {
        ScoreTotal += ScoreNumber;
        UpdateScore();
    }

    void UpdateScore()
    {
       
        ScoreText.text = "Score : " + ScoreTotal;
    }

    void ReStart()
    {
        ReStartText.text = "Press 'R' for ReStart";
        reStart = true;

    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

    

}