
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    public int score = 0; // Tracks the current score
    public int highScore; // Stores the highest score achieved
    public static int lastScore = 0; // Stores the last recorded score

    public Text scoreText; // UI text displaying the current score
    public Text highScoreText; // UI text displaying the high score
    public Text lastScoreText; // UI text displaying the last score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Score()); // Starts a coroutine that increments the score over time
        StartCoroutine(Reload()); // Starts a coroutine that reloads the scene after a random duration

        highScore = PlayerPrefs.GetInt("high_score", 0); // Retrieves the saved high score from PlayerPrefs

        highScoreText.text = "HighScore: " + highScore.ToString(); // Updates the high score UI text
        lastScoreText.text = "LastScore: " + lastScore.ToString(); // Updates the last score UI text
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); // Updates the score UI text

        if (score > highScore) // Checks if the current score is higher than the high score
        {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore); // Saves the new high score
            Debug.Log("High Score:" + highScore); // Logs the new high score in the console
        }
    }

    // Coroutine to increment the score every 0.8 seconds
    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            score = score + 1;
            lastScore = score;
        }
    }

    // Coroutine to reload the scene after a random time between 5 to 10 seconds
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(Random.Range(150, 160));
        SceneManager.LoadScene("Game"); // Reloads the game scene
    }
}