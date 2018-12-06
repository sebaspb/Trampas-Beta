using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaDeParedNivel3 : MonoBehaviour
{

    public GameObject Trigger;
    bool activada = false;





    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger && activada == false)
        {

                ManagerNivel3.ControlPalancas += 1;
                activada = true;
        
        

        }


    }

    }
