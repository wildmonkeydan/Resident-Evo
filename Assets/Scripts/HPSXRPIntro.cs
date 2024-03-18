using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class HPSXRPIntro : MonoBehaviour
{
    private VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += End;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void End(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu");
    }
}
