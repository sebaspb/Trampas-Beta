using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Éste script se utiliza para definir objetos letales que matan al jugador de inmediato por lo genera se utiliza en colisiones en caso de que el jugador salga fuera del mapa y en un par de trampas.
/// </summary>

public class ObjetoLetal : MonoBehaviour
{
    [Header("<COMPORTAMIENTO>")]
    [Tooltip("Daño causado por el objeto letal.")]
    public float daño;


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.SaludJugador -= daño;

        }

    }
}
