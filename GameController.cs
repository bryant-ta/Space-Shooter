using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;

    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public Text victoryText;
    public Text restartText;
    public Text backText;
    public Text submitText;
    public Text levelText;
    public Text controlsText;
    public Text storyText;
    public InputField input;

    private IEnumerator cor;
    private IEnumerator cor2;
    private bool going = true;
    private bool victory = false;

    void Start()
    {
        cor = Score();
        cor2 = TextController();
        StartCoroutine(cor);
        StartCoroutine(cor2);
    }
	void Update () {

        scoreText.text = "Score: " + GlobalVariables.score;
        livesText.text = "Lives: " + GlobalVariables.lives;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        GameOver();
        Victory();
	}

    void Restart()
    {
        SceneManager.LoadScene(1);
    }

    void GameOver()
    {
        if (player == null && !victory)
        {
            going = false;
            input.gameObject.SetActive(true);
            gameOverText.text = "GAMEOVER";
            submitText.text = "Press 'Enter' to submit your name and score!";
            restartText.text = "Press 'F5' to restart";
            backText.text = "Press 'Backspace' to return to menu";
            if (Input.GetKey(KeyCode.F5))
            {
                Restart();
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void Victory()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && GameObject.FindWithTag("Boss").GetComponent<BossController>().going == false)
        {
            victory = true;
            going = false;
            input.gameObject.SetActive(true);
            victoryText.text = "VICTORY!";
            submitText.text = "Press 'Enter' to submit your name and score!";
            restartText.text = "Press 'F5' to restart";
            backText.text = "Press 'Backspace' to return to menu";
            if (Input.GetKey(KeyCode.F5))
            {
                Restart();
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AddToLeaderboard(string playerName)
    {
        int score = GlobalVariables.score;

        GlobalVariables.scoreList.Add(score);
        GlobalVariables.scoreList.Sort();
        
        GlobalVariables.playerNameList.Insert(GlobalVariables.scoreList.IndexOf(score), playerName);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    IEnumerator Score()
    {
        while (going)
        {
            yield return new WaitForSeconds(0.5F);
            if (GlobalVariables.score > 0)
            {
                GlobalVariables.score -= 10;
            }
        }
    }

    IEnumerator TextController()
    {
        yield return new WaitForSeconds(7);
        levelText.enabled = false;
        if (controlsText != null && storyText != null)
        {
            controlsText.enabled = false;
            storyText.enabled = false;
        }
    }
}