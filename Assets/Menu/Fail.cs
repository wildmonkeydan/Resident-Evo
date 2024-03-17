using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
