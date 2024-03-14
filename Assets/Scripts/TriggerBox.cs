using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    public UnityEvent trigger;
    public string layer;
    public bool oneShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(layer != string.Empty)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer(layer))
            {
                trigger.Invoke();
            }
        }
        else
        {
            trigger.Invoke();
        }
        

        if(oneShot)
        {
            Destroy(gameObject);
        }
    }
}
