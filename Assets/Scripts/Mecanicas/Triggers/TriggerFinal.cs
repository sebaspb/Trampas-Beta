using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Éste script se usa en el último nivel para mostrar la pantalla de victoria en caso de contacto con el último trigger
/// </summary>

public class TriggerFinal : MonoBehaviour
{
    [Header("<COMPORTAMIENTO>")]
    [Tooltip("Variable de control que comprueba si el jugador ya ha ganado")]
    public static bool ganaste = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            ganaste = true;
        }

    }

}
