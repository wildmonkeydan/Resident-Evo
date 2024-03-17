using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public RawImage background;
    public Texture menuBack;
    public GameObject menuStuff;
    public GameObject difficultyChoice;
    public GameObject startButton;

    private float timer = 0;
    private bool logoDone = false;

    // Start is called before the first frame update
    void Start()
    {
        menuStuff.SetActive(false);
        difficultyChoice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4 && !logoDone)
        {
            background.texture = menuBack;
            logoDone = true;
            menuStuff.SetActive(true);
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        difficultyChoice.SetActive(true);
    }

    public void Easy()
    {
        PlayerPrefs.SetFloat("Fuel", 15000f);
        PlayerPrefs.SetInt("EscapeTime", 120);
        Game();
    }

    public void Normal()
    {
        PlayerPrefs.SetFloat("Fuel", 12500f);
        PlayerPrefs.SetInt("EscapeTime", 90);
        Game();
    }

    public void Hard()
    {
        PlayerPrefs.SetFloat("Fuel", 10000f);
        PlayerPrefs.SetInt("EscapeTime", 60);
        Game();
    }

    void Game()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
