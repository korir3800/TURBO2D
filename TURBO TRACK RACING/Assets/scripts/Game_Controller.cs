using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{

    public Text HighscoreText;
    public Text ScoreText;


    public int score;
    public int highscore;

    public Score_Manager Score_Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscore= PlayerPrefs.GetInt("highscore");
        score = Score_Manager.score;

        HighscoreText.text = highscore.ToString();
        ScoreText.text = score.ToString();
    }
}
