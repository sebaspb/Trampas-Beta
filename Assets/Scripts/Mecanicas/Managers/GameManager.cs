using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

/// <summary>
/// Éste script controla las mecánicas iniciales del jugador, así como las opciones de reinicio del mismo, controla el progreso del jugador y el cambio del nivel.
/// </summary>
/// 
public class GameManager : MonoBehaviour



{

    [Header("<JUGADOR>")]
    [Tooltip("Objeto del jugador")]
    GameObject Jugador;
    [Tooltip("Salud del jugador")]
    public static float SaludJugador = 500f;

    [Header("<VARIABLES INTERNAS>")]
    [Tooltip("Array que contiene los diferentes spawns de los niveles")]
    [SerializeField]
    public GameObject[] Spawn;
    [Tooltip("Array que contiene los diferentes niveles")]
    public GameObject[] Niveles;
    [Tooltip("Variable de control para el nivel cargado")]
    public static int NivelCargado = 0;
    [Tooltip("Variable de control para el nivel anterior")]
    int NivelAnterior = 0;
    [Tooltip("Variable de control para el nivel actual")]
    public static int IDNivelActual =0;
    [Tooltip("Variable de control para el spawn actual")]
    public static GameObject SpawnActual;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Jugador = GameObject.FindGameObjectWithTag("Player");
        Niveles[NivelCargado].SetActive(true);
        Niveles[NivelCargado+1].SetActive(true);
        SpawnActual = Spawn[IDNivelActual];
        Jugador.GetComponent<FPController>().Constraints.Move = false;
        Jugador.GetComponent<FPController>().Constraints.Jump = false;
        Jugador.GetComponent<FPController>().Constraints.JumpFromAir = false;
        Jugador.GetComponent<FPController>().Constraints.Sprint = !true;
        Jugador.GetComponent<FPController>().Constraints.Crouch = !true;
        Jugador.GetComponent<FPController>().Constraints.Prone = !true;
        Jugador.GetComponent<FPController>().Constraints.Slide = !true;
        Jugador.GetComponent<FPController>().Constraints.Look = false;
        Jugador.GetComponent<FPController>().Constraints.Lean = !true;
        Jugador.GetComponent<FPController>().Constraints.HeadBob = !true;


        ReiniciarJugador();

    }

    // Update is called once per frame
    void Update()
    {
        
            
       
            if (NivelAnterior != NivelCargado)
            {
            
                Niveles[NivelCargado - 1].SetActive(false);
                Niveles[NivelCargado].SetActive(true);
            
                if(IDNivelActual < 4)
                {
                    IDNivelActual += 1;
                    Niveles[NivelCargado + 1].SetActive(true);
                    NivelAnterior = NivelCargado;
                }

                SpawnActual = Spawn[IDNivelActual];
            
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

 
    

}
