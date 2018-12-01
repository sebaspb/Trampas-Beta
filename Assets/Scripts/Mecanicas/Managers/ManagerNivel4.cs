using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel4 : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Spawn;
    public static int ControlPalancas = 0;
    public GameObject TriggerPuertaObjetivo;
    public static int ControlMuertes = 0;
    public GameObject PisoTrampa;
    AudioSource AS_Dialogos;
    public AudioClip ObjetivoNivel4;

    bool sonidocorrecto = false;

    public AudioClip SonidoCorrecto;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IDNivelActual == 3)
        {
            Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = true;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = false;
            Jugador.GetComponent<FPController>().Constraints.Sprint = true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = true;
            Jugador.GetComponent<FPController>().Constraints.Prone = !true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;
            AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();
        }
        if (VariablesJugador.SaludJugador <= 0)
        {
            //Destroy(Jugador.gameObject);
            ControlMuertes += 1;
            ReiniciarJugador();

        }

                 if (ControlPalancas == 0)
        {
            
            PisoTrampa.GetComponent<MeshCollider>().enabled = false;
                if (!sonidocorrecto) { 
            AS_Dialogos.PlayOneShot(SonidoCorrecto);
            AS_Dialogos.PlayOneShot(ObjetivoNivel4);
                sonidocorrecto = true;}

            
        }       

        
       
        
    }

    void ReiniciarJugador()
    {
      
        //Jugador.transform.position = Spawn.transform.position;
        //Jugador.transform.rotation = Spawn.transform.rotation;



    }

 


}
