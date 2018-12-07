using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla el comportamiento del nivel 3, principalmente las habilidades que el jugador puede usar en dicho nivel 
/// y las animaciones que se usarán y su comportamiento, así como manejo de diálogos y trampas específicas
/// </summary>
public class ManagerNivel3 : MonoBehaviour
{
    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    public GameObject Jugador;

    [Header("<VARIABLES INTERNAS>")]
    [Tooltip("Total de palancas activadas del nivel")]
    public static int ControlPalancas = 0;
    [Tooltip("Trigger usado para abrir la puerta final")]
    public GameObject TriggerPuertaObjetivo;
    [Tooltip("Control de muertes del nivel")]
    public static int ControlMuertes = 0;
    [Tooltip("Trigger usado para subir el techo")]
    public GameObject TriggerSubirTecho;
    [Tooltip("Array usado para contener las palancas que encienden la trampa")]
    public GameObject[] PalancasTrampa;
    [Tooltip("Variable que comprueba si ya se puede cerrar la zona de la trampa")]
    public bool cerrarTrampa;
    [Tooltip("trigger usado para cerrar la zona de la trampa")]
    public GameObject TriggerCerrarTrampa;

    [Header("<AUDIO>")]
    [Tooltip("Audioclip del sonido a reproducir")]
    public AudioClip SonidoCorrecto;
    [Tooltip("Variable usada para comporbar si se debe reproducir un osnido bajo ciertas circunstancias")]
    bool sonidocorrecto = false;
    [Tooltip("Audiosource de los diálogos")]
    AudioSource AS_Dialogos;
    [Tooltip("Audioclip del nivel 4")]
    public AudioClip Objetivo;
    [Tooltip("Trigger usado para desactivar un diálogo en ciertas circunstancias")]
    public GameObject ocultardialogo;

void Start()
{
    
    AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
       
}
    // Update is called once per frame
    void Update()
    {
        if (GameManager.IDNivelActual == 2)
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


        }


        if (GameManager.SaludJugador <= 0)
        {
          
            ControlMuertes += 1;
        }






        if (PalancasTrampa[0].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[1].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[2].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[3].GetComponent<PalancaDePared>().activada == true && !cerrarTrampa)
        {

            cerrarTrampa = true;
            ocultardialogo.SetActive(false);
            TriggerCerrarTrampa.SetActive(true);
            
        }

        
        if (ControlPalancas >= 8 && TriggerPuertaObjetivo !=null)
        {

            
            TriggerPuertaObjetivo.SetActive(true);

            if (!sonidocorrecto)
            { 

                GetComponent<AudioSource>().PlayOneShot(SonidoCorrecto);
                sonidocorrecto = true;
                AS_Dialogos.PlayOneShot(Objetivo);

            }
           
            
        }

        if (ControlMuertes!=0 && TriggerSubirTecho != null)
        {

            StartCoroutine(SubirTecho(6));

        }
        
    }




    IEnumerator SubirTecho(float time)
    {

      yield return new WaitForSeconds(time);
      TriggerSubirTecho.SetActive(true);

    }
}
