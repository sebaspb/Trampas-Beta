using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel4 : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject CamaraJugador;
    public GameObject Spawn;
    public static int ControlPalancasNivel3 = 0;
    public GameObject TriggerPuertaObjetivo;
    public static int ControlMuertes = 0;
    public GameObject TriggerSubirTecho;
    public GameObject Nivel;
    public GameObject[] PalancasTrampa;
    public bool cerrarTrampa;
    public GameObject TriggerCerrarTrampa;
    public GameObject trampa;
    public GameObject PisoTrampa;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
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

                 if (ControlPalancasNivel3 == 6)
        {
            PisoTrampa.GetComponent<MeshCollider>().enabled = false;
        }       

        
        if (ControlPalancasNivel3 >= 8 && TriggerPuertaObjetivo !=null)
        {

            TriggerPuertaObjetivo.SetActive(true);


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
