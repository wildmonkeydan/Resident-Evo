using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VehicleBehaviour
{
    public class Overseer : MonoBehaviour
    {
        public int score;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI fuelText;

        private bool fuelOut = false;
        
        // Start is called before the first frame update
        void Start()
        {
    
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            scoreText.text = "SCORE: " + score.ToString();        
        }

        void Update()
        {
            if (fuelOut && Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        public void OutOfFuel()
        {
            fuelText.text = "Out of Fuel!\nPress enter to restart";
            fuelOut = true;
        }

        public void Results()
        {
            PlayerPrefs.SetFloat("Time", Time.timeSinceLevelLoad);
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }
}
