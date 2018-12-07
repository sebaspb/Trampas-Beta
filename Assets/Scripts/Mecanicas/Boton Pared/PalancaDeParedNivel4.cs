using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Éste scrit se usa para cambiar el numero de palancas activadas en el nivel 4 cada vez que se activa 1, la variable de la cantidad de palancas está en el manager del nivel correspondiente.
/// </summary>
public class PalancaDeParedNivel4 : MonoBehaviour
{
    [Header("<COMPORTAMIENTO>")]
    [Tooltip("Trigger usado para comprobar si el jugador puede usar la palanca")]
    public GameObject Trigger;
    [Tooltip("Variable usada para comprobar que la palanca no ha sido activada")]
    bool activada = false;
 

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger && activada == false)
        {

                ManagerNivel4.ControlPalancas += 1;
                activada = true;
        
        }


    }

}
