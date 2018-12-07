using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla el comportamiento del nivel 5, principalmente las habilidades que el jugador puede usar en dicho nivel 
/// y las animaciones que se usarán y su comportamiento y los diálogos del  nivel.
/// </summary>
public class ManagerNivel4 : MonoBehaviour
{
    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    public GameObject Jugador;

    [Header("<VARIABLES INTERNAS>")]
    [Tooltip("Total de palancas activadas del nivel")]
    public static int ControlPalancas = 0;
    [Tooltip("Control de muertes del nivel")]
    public static int ControlMuertes = 0;
    [Tooltip("Objeto del piso trampa")]
    public GameObject PisoTrampa;

    [Header("<AUDIO>")]
    [Tooltip("Audiosource de los diálogos")]
    AudioSource AS_Dialogos;
    [Tooltip("Audioclip del nivel 4")]
    public AudioClip ObjetivoNivel4;
    [Tooltip("Variable usada para comporbar si se debe reproducir un osnido bajo ciertas circunstancias")]
    bool sonidocorrecto = false;
    [Tooltip("Audioclip del sonido a reproducir")]
    public AudioClip SonidoCorrecto;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.IDNivelActual == 3)
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


        if (ControlPalancas == 6)
        {
            
            PisoTrampa.GetComponent<MeshCollider>().enabled = false;

            if (!sonidocorrecto)
            { 

                AS_Dialogos.PlayOneShot(SonidoCorrecto);
                AS_Dialogos.PlayOneShot(ObjetivoNivel4);
                sonidocorrecto = true;

            }

            
        }       

        
       
        
    }



 


}
