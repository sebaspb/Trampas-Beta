using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaDeParedNivel4 : MonoBehaviour
{

    public GameObject Trigger;
    bool activada = false;
 




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger && activada == false)
        {

                ManagerNivel4.ControlPalancas += 1;
                activada = true;
        

             
     

        }


    }

    }
