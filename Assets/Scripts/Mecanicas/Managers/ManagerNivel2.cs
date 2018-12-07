using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla el comportamiento del nivel 2, principalmente las habilidades que el jugador puede usar en dicho nivel 
/// y las animaciones que se usarán y su comportamiento y los diálogos del  nivel.
/// </summary>

public class ManagerNivel2 : MonoBehaviour
{
    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    GameObject Jugador;

    [Header("<AUDIO>")]
    [Tooltip("Audiosource de los diálogos")]
    AudioSource AS_Dialogos;
  
    private void Start()
    {
        
        Jugador = GameObject.FindWithTag("Player");
        AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
  
    }
    // Update is called once per frame
    void Update()
    {

        if (GameManager.IDNivelActual == 1)
        {
            Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = true;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = true;
            Jugador.GetComponent<FPController>().Constraints.Sprint = !true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = true;
            Jugador.GetComponent<FPController>().Constraints.Prone = !true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;


        }

    }

  
}
