using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public RawImage background;
    public GameObject foreground;
    public TextMeshProUGUI score;
    public TextMeshProUGUI ranking;
    public TextMeshProUGUI time;
    public GameObject gold;

    private int scoreValue;
    private float clearTime;
    private bool fade = false;
    private char rank;
    // Start is called before the first frame update
    void Start()
    {
        gold.SetActive(false);
        
        scoreValue = PlayerPrefs.GetInt("Score");
        clearTime = PlayerPrefs.GetFloat("Time") / 60;

        score.text = "SCORE: " + scoreValue.ToString();
        time.text = "TIME: " + string.Format("{0:F2}", clearTime);

        float timeRank = clearTime / 0.5f;
        float scoreRank = scoreValue / 1000;

        if(timeRank <= 7 && scoreRank >= 1.5f)
        {
            rank = 'S';
            gold.SetActive(true);
            PlayerPrefs.SetInt("Gold", 1);
            PlayerPrefs.Save();
        }
        else if(timeRank <= 9 && scoreRank >= 1.5f)
        {
            rank = 'A';
        }
        else if(timeRank <= 11 && scoreRank >= 1.25f)
        {
            rank = 'B';
        }
        else if(timeRank <= 13 && scoreRank >= 1.25f)
        {
            rank = 'C';
        }
        else
        {
            rank = 'D';
        }

        ranking.text = "RANK " + (rank == 'S' ? "<color=\"yellow\">": "") + rank;
        foreground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fade)
        {
            background.color += new Color(0, 0, 0, Time.deltaTime / 2);

            if(background.color.a > 1f)
            {
                fade = true;
                foreground.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }
}
