using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public RawImage credits;
    public float speed = 30f;

    private RawImage image;
    private bool isFading = false;
    private bool rolling = false;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFading)
        {
            image.color += new Color(0, 0, 0, Time.deltaTime);

            if(image.color.a > 1f)
            {
                isFading = false;
                rolling = true;
            }
        }

        if (rolling)
        {
            credits.rectTransform.localPosition += new Vector3(0, speed * Time.deltaTime);
            //credits.rectTransform.position = new Vector3(credits.rectTransform.position.x, credits.rectTransform.position.y, 0);

            if(credits.rectTransform.localPosition.y >= 1600)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Fade()
    {
        isFading = true;
    }
}
