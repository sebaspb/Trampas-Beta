using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel2 : MonoBehaviour
{
    GameObject Jugador;
    AudioSource AS_Dialogos;
  
    private void Start()
    {
Debug.Log(GameManager.IDNivelActual);
        Jugador = GameObject.FindWithTag("Player");
        AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();

         if(GameManager.IDNivelActual == 1)
        {
            Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = true;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = false;
            Jugador.GetComponent<FPController>().Constraints.Sprint = !true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = true;
            Jugador.GetComponent<FPController>().Constraints.Prone =!true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;


        }
          
    }
    // Update is called once per frame
    void Update()
    {

       
     
    }

  
}
