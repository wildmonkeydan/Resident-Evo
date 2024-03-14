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
                break;
            case Objective.Escape:
                text.text = "Escape!";
                break;
        }
    }

    public void BreakEquipment()
    {
        currentLabEquipment--;
    }
}
