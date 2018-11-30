using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel5 : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Spawn;
   public static int ControlMuertes = 0;
    public GameObject Nivel;
    AudioSource AS_Dialogos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.IDNivelActual == 4)
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

        if (VariablesJugador.SaludJugador<=0 && GameManager.IDNivelActual== 4){
            {

                Nivel.GetComponent<Animator>().Play("Ascensor Inferior", 0, 0);

            }


        }            
        
    }

    void ReiniciarJugador()
    {
        //Jugador.transform.position = Spawn.transform.position;
        //Jugador.transform.rotation = Spawn.transform.rotation;


    }

 


}
