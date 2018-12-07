using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Éste script controla el sistema para desactivar triggers mediante un botón, en algunos casos también se utliza para desactivar objetos de juego.
/// El trigger que se comprueba por lo general hace referencia al trigger del botón o palanca que se usará.
/// El delay es para que el trigger o objeto no se desactive de inmediato.
/// </summary>
public class DisableTriggerConBoton : MonoBehaviour
{
    [Header("<Deshabilitar>")]
    [Tooltip("Objeto o Trigger a Desactivar")]
    public GameObject TriggerADesactivar;
    [Tooltip("Trigger usado para comporabar si el jugador está en trigger")]
    public GameObject Trigger;
    [Tooltip("Delay antes de desactivar")]
    public float Delay;


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
        TriggerADesactivar.SetActive(false);
    }
}
