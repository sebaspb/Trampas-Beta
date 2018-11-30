using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCambiarNivel : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
                             if (GameManager.IDNivelActual < 4) { 
                    GameManager.NivelCargado += 1;
                    Destroy(gameObject);
            }
        }
           
        }
    }


