using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Éste script se encarga de revisar si el jugador está dentro del trigger asignado para desencadenar cierta acción, por lo general se utiliza al momento de accionar botones, palancas o trampas.
/// </summary>

public class RevisionTrigger : MonoBehaviour
{
    [Tooltip("Variable usada para comprobar si se está en trigger o no")]
    public bool EstaEnTrigger = false;
  

    private void OnTriggerEnter(Collider Jugador)
    {

        if (Jugador.CompareTag("Player"))
        {

            EstaEnTrigger = true;

        }

    }

    private void OnTriggerExit(Collider Jugador)
    {

        if (Jugador.CompareTag("Player"))
        {

            EstaEnTrigger = false;

        }

    }
}
