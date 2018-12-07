using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Éste script se usa para triggers especiales que cambian el ID del nivel actual en el gamemanager y la función gameover y reaparición funcionen correctamente
/// </summary>
public class TriggerCambiarNivel : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            if (GameManager.IDNivelActual < 4)
            { 

                GameManager.NivelCargado += 1;
                Destroy(gameObject);

            }

        }
           
    }
}


