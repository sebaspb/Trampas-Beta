using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTriggerConBoton : MonoBehaviour
{
    public GameObject TriggerAActivar;
    public GameObject Trigger;
    public float Delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
        {

            StartCoroutine(Activar(Delay));
            

        }
    }

    IEnumerator Activar(float time)
    {

        yield return new WaitForSeconds(time);
        TriggerAActivar.SetActive(true);
    }
}
