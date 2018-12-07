using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla el comportamiento del nivel 1, principalmente las habilidades que el jugador puede usar en dicho nivel 
/// y las animaciones que se usarán y su comportamiento y los diálogos del  nivel.
/// </summary>
/// 
public class ManagerNivel1 : MonoBehaviour
{
    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    GameObject Jugador;

    [Header("<AUDIO>")]
    [Tooltip("Audiosource de los diálogos")]
    AudioSource AS_Dialogos;
    [Tooltip("Audioclip del nivel 1")]
    public AudioClip AC_Bienvenida;

    private void Start()
    {
        if(GameManager.IDNivelActual==0)
        {
            Jugador = GameObject.FindWithTag("Player");
            AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
            AS_Dialogos.PlayOneShot(AC_Bienvenida);
            StartCoroutine(HabilitarMovimiento(42f));

        }
    }


    IEnumerator HabilitarMovimiento(float time)
    {

        yield return new WaitForSeconds(time);
         Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = false;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = false;
            Jugador.GetComponent<FPController>().Constraints.Sprint = !true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = !true;
            Jugador.GetComponent<FPController>().Constraints.Prone =!true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = !true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;

    }
}
