using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel3 : MonoBehaviour
{
    public GameObject Jugador;
    public static int ControlPalancas = 0;
    public GameObject TriggerPuertaObjetivo;
    public static int ControlMuertes = 0;
    public GameObject TriggerSubirTecho;
    public GameObject[] PalancasTrampa;
    public bool cerrarTrampa;
    public GameObject TriggerCerrarTrampa;

    public AudioClip SonidoCorrecto;
    bool sonidocorrecto = false;

    AudioSource AS_Dialogos;

    public AudioClip Objetivo;

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
            if (!sonidocorrecto) { 
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
