using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla el comportamiento del nivel 5, principalmente las habilidades que el jugador puede usar en dicho nivel 
/// y las animaciones que se usarán y su comportamiento.
/// </summary>

public class ManagerNivel5 : MonoBehaviour
{
    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    public GameObject Jugador;

    [Header("<COMPORTAMIENTO>")]
    [Tooltip("Prefab de éste nivel")]
    public GameObject Nivel;
    [Header("<AUDIO>")]

    [Tooltip("AudioSource que contendrá los diálogos")]
    AudioSource AS_Dialogos;



    // Update is called once per frame
    void Update()
    {
        if(GameManager.IDNivelActual == 4)
        {
            Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = true;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = true;
            Jugador.GetComponent<FPController>().Constraints.Sprint = true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = true;
            Jugador.GetComponent<FPController>().Constraints.Prone = !true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;
            AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
        }

        if (GameManager.SaludJugador<=0 && GameManager.IDNivelActual>= 4){
            {

                Nivel.GetComponent<Animator>().Play("Ascensor Inferior", 0, 0);

            }


        }            
        
    }
         
}
