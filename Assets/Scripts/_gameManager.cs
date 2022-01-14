using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _gameManager : MonoBehaviour
{
    public GameObject coinsHolder;
    public GameObject platformsHolder;
    public GameObject hud;
    public GameObject gameOverScreen;

    public Button retryButton;

    public Text scoreField;
    public Text finalScoreField;

    float currentScore = 0;

    bool levelCompleted, startOver;

    void Start()
    {
        levelCompleted = false;
        startOver = false;

        Time.timeScale = 1f;
        scoreField.text = "0";

        m_panelActivity(true);
        gameOverScreen.SetActive(false);

        finalScoreField.fontSize = 80;
    }
    private void Update()
    {
        m_levelComplete();
    }


    public void m_updateScore(float scoreInc)
    {
        //increment by 10 here
        currentScore += scoreInc;
        scoreField.text = currentScore.ToString();
    }

    public void m_gameOver()
    {
        levelCompleted = false;

        Time.timeScale = 0f;

        m_panelActivity(false);
        gameOverScreen.SetActive(true);

        finalScoreField.text = "Your score is: " + currentScore.ToString();
    }

    void m_panelActivity(bool activity)
    {
        coinsHolder.SetActive(activity);
        platformsHolder.SetActive(activity);
        hud.SetActive(activity);
    }

    void m_levelComplete()
    {
        if(currentScore == 80)
        {
            if((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_1")))
            {
                Time.timeScale = 0f;

                m_panelActivity(false);
                gameOverScreen.SetActive(true);

                finalScoreField.fontSize = 40;
                finalScoreField.text = "Level 1 Complete!";
                retryButton.GetComponentInChildren<Text>().text = "Level 2?!";
                levelCompleted = true;
            }
        }
        if (currentScore == 80 && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_2")))
        {
            Time.timeScale = 0f;

            m_panelActivity(false);
            gameOverScreen.SetActive(true);

            finalScoreField.fontSize = 40;
            finalScoreField.text = "You just beat the most difficult GAME, congratulations!";
            retryButton.GetComponentInChildren<Text>().text = "...just play again";

            levelCompleted = false;
            startOver = true;
        }
    }

    public void m_onRetry()
    {
        if(levelCompleted)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        if (startOver == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
