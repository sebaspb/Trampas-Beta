﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Éste script controla el sistema para activar triggers mediante un botón, en algunos casos también se utliza para activar objetos de juego.
/// El trigger que se comprueba por lo general hace referencia al trigger del botón o palanca que se usará.
/// El delay es para que el trigger o objeto no se active de inmediato.
/// </summary>
public class EnableTriggerConBoton : MonoBehaviour
{
    [Header("<Habilitar>")]
    [Tooltip("Objeto o Trigger a activar")]
    public GameObject TriggerAActivar;
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
        TriggerAActivar.SetActive(true);
    }
}
