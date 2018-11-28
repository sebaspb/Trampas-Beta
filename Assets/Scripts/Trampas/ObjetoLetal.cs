using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLetal : MonoBehaviour
{

    public float daño;


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
            {

            VariablesJugador.SaludJugador -= daño;

        
        }

    }
}
