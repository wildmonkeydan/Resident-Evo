using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    [System.Serializable]
    public enum Objective
    {
        FindLab,
        DestroyLab,
        KillTyrant,
        Escape,
        Ending
    }

    public Objective objective = Objective.FindLab;
    public TextMeshProUGUI text;
    public TextMeshProUGUI countdown;
    public GameObject labParent;
    public GameObject explosion;
    public Transform car;
    public GameObject tyrant;
    public Transform pod;
    public GameObject helicopter;
    public AudioSource jukebox;
    public AudioClip bigBad;
    public AudioClip bigExplosion;
    public RawImage fade;
    public PlayableDirector endingDirector;

    private int currentLabEquipment;
    private float escapeTimer = 60f;
    private bool failed = false;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Find the lab";

        currentLabEquipment = labParent.transform.childCount;
        helicopter.SetActive(false);
        escapeTimer = PlayerPrefs.GetInt("EscapeTime");
    }

    // Update is called once per frame
    void Update()
    {
        switch(objective)
        {
            case Objective.FindLab:
                break;
            case Objective.DestroyLab:
                if(currentLabEquipment <= 0)
                {
                    ChangeObjective(2);
                }
                break;
            case Objective.Escape:
                escapeTimer -= Time.deltaTime;

                if (escapeTimer >= 0)
                {
                    countdown.text = string.Format("{0:F2}", escapeTimer);
                }
                else
                {
                    if (!failed)
                    {
                        failed = true;
                        jukebox.PlayOneShot(bigExplosion);
                    }
                    fade.color += new Color(0, 0, 0, Time.deltaTime);

                    if(fade.color.a >= 1)
                    {
                        SceneManager.LoadScene("Fail");
                    }
                }

                break;
        }
    }

    public void ChangeObjective(int obj)
    {
        objective = (Objective)obj;
        switch(objective)
        {
            case Objective.FindLab:
                text.text = "Find the lab";
                break;
            case Objective.DestroyLab:
                text.text = "Destroy the lab equipment";
                break;
            case Objective.KillTyrant:
                text.text = "Kill the tyrant";

                Vector3 podPos = pod.position;
                Destroy(pod.gameObject);
                Instantiate(tyrant, podPos, Quaternion.identity);
                jukebox.Stop();
                jukebox.clip = bigBad;
                jukebox.Play();

                break;
            case Objective.Escape:
                text.text = "Escape!";
                InvokeRepeating("Explosion", 0.5f, 1f);
                helicopter.SetActive(true);
                break;
            case Objective.Ending:
                endingDirector.Play();
                break;
        }
    }

    public void BreakEquipment()
    {
        currentLabEquipment--;
    }

    void Explosion()
    {
        GameObject obj = Instantiate(explosion, car.position + Random.onUnitSphere, Random.rotation);
        obj.transform.localScale = Vector3.one * Random.Range(1f, 6f);
    }
}
