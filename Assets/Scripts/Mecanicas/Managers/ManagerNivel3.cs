using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel3 : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Spawn;
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

void Start()
{

    AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
       if(GameManager.IDNivelActual == 2)
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

        if (VariablesJugador.SaludJugador <= 0)
        {
            //Destroy(Jugador.gameObject);
            ControlMuertes += 1;
            ReiniciarJugador();

        }






        if (PalancasTrampa[0].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[1].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[2].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[3].GetComponent<PalancaDePared>().activada == true && !cerrarTrampa)
        {
            cerrarTrampa = true;


           TriggerCerrarTrampa.SetActive(true);
            
        }

        
        if (ControlPalancas >= 8 && TriggerPuertaObjetivo !=null)
        {

            TriggerPuertaObjetivo.SetActive(true);
            if (!sonidocorrecto) { 
            GetComponent<AudioSource>().PlayOneShot(SonidoCorrecto);
                sonidocorrecto = true;
            }

        }

        if (ControlMuertes!=0 && TriggerSubirTecho != null)
        {

            StartCoroutine(SubirTecho(6));

        }
        
    }

    void ReiniciarJugador()
    {
        
        //Jugador.transform.position = Spawn.transform.position;
        //Jugador.transform.rotation = Spawn.transform.rotation;
       
     


    }


    IEnumerator SubirTecho(float time)
    {

        yield return new WaitForSeconds(time);
      TriggerSubirTecho.SetActive(true);
    }
}
