using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [System.Serializable]
    public enum Objective
    {
        FindLab,
        DestroyLab,
        KillTyrant,
        Escape
    }

    public Objective objective = Objective.FindLab;
    public TextMeshProUGUI text;
    public GameObject labParent;
    public GameObject explosion;
    public Transform car;
    public GameObject tyrant;
    public Transform pod;

    public int currentLabEquipment;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Find the lab";

        currentLabEquipment = labParent.transform.childCount;
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

                break;
            case Objective.Escape:
                text.text = "Escape!";
                InvokeRepeating("Explosion", 0.5f, 1f);
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
