using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class GameManager : MonoBehaviour



{
     

    GameObject Jugador;

    [SerializeField]
    public GameObject[] Spawn;

    public GameObject[] Niveles;

    public static int NivelCargado = 0;

    int NivelAnterior = 0;

    public GameObject spawn5;

    public static int IDNivelActual = 0;

    public static GameObject SpawnActual;
    

    // Start is called before the first frame update
    void Start()
    {

        Jugador = GameObject.FindGameObjectWithTag("Player");
        Niveles[NivelCargado].SetActive(true);
        Niveles[NivelCargado + 1].SetActive(true);
        SpawnActual = Spawn[IDNivelActual];

        ReiniciarJugador();

    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        if (Input.GetKeyDown(KeyCode.Z)) VariablesJugador.SaludJugador =- VariablesJugador.SaludJugador;
        
    

        if (NivelAnterior != NivelCargado)
        {
            
            Niveles[NivelCargado - 1].SetActive(false);
            Niveles[NivelCargado].SetActive(true);
            Niveles[NivelCargado + 1].SetActive(true);
            IDNivelActual += 1;
            SpawnActual = Spawn[IDNivelActual];
            NivelAnterior = NivelCargado;

        }

    }


    void ReiniciarJugador()
    {

        Jugador.GetComponent<FPController>().initilized = false;
        Jugador.GetComponent<FPController>().enabled = false;
        Jugador.transform.position = SpawnActual.transform.position;
        Jugador.transform.rotation = SpawnActual.transform.rotation;
        Jugador.GetComponent<FPController>().enabled = true;
        Jugador.GetComponent<FPController>().Init();
    }

    public void MovimientoJugador()
    {

        if(IDNivelActual == 0)
        {

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

         if(IDNivelActual == 1)
        {

            Jugador.GetComponent<FPController>().Constraints.Move = true;
            Jugador.GetComponent<FPController>().Constraints.Jump = true;
            Jugador.GetComponent<FPController>().Constraints.JumpFromAir = false;
            Jugador.GetComponent<FPController>().Constraints.Sprint = !true;
            Jugador.GetComponent<FPController>().Constraints.Crouch = !true;
            Jugador.GetComponent<FPController>().Constraints.Prone =!true;
            Jugador.GetComponent<FPController>().Constraints.Slide = !true;
            Jugador.GetComponent<FPController>().Constraints.Look = true;
            Jugador.GetComponent<FPController>().Constraints.Lean = !true;
            Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;

        }

        

    }

}
