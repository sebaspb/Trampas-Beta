using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class GameManager : MonoBehaviour



{
     

    GameObject Jugador;
    GameObject Spawn;

    public GameObject[] Niveles;

    public static int NivelCargado = 0;

    int NivelAnterior = 0;

    

    // Start is called before the first frame update
    void Start()
    {

        Jugador = GameObject.FindGameObjectWithTag("Player");
        Niveles[NivelCargado].SetActive(true);
        Niveles[NivelCargado + 1].SetActive(true);
        Spawn = GameObject.Find("SpawnNivel 1");
        ReiniciarJugador();

    }

    // Update is called once per frame
    void Update()
    {
   

        if (NivelAnterior != NivelCargado)
        {

            Niveles[NivelCargado - 1].SetActive(false);
            Niveles[NivelCargado].SetActive(true);
            Niveles[NivelCargado + 1].SetActive(true);
            NivelAnterior = NivelCargado;

        }

    }


    void ReiniciarJugador()
    {
        Jugador.GetComponent<FPController>().initilized = false;
        Jugador.GetComponent<FPController>().enabled = false;
        Jugador.transform.position = Spawn.transform.position;
        Jugador.transform.rotation = Spawn.transform.rotation;
        Jugador.GetComponent<FPController>().enabled = true;
        Jugador.GetComponent<FPController>().Init();
        VariablesJugador.SaludJugador = 500;
        VariablesJugador.JugadorMuerto = false;


    }


    }
