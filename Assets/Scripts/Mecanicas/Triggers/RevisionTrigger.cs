using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisionTrigger : MonoBehaviour
{

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
