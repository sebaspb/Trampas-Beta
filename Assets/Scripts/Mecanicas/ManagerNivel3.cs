using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel3 : MonoBehaviour
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




        if (PalancasTrampa[0].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[1].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[2].GetComponent<PalancaDePared>().activada == true &&
            PalancasTrampa[3].GetComponent<PalancaDePared>().activada == true && !cerrarTrampa)
        {
            cerrarTrampa = true;


           TriggerCerrarTrampa.SetActive(true);
            
        }

        
        if (ControlPalancasNivel3 >= 8 && TriggerPuertaObjetivo !=null)
        {

            TriggerPuertaObjetivo.SetActive(true);


        }

        if (ControlMuertes!=0 && TriggerSubirTecho != null)
        {

            TriggerSubirTecho.SetActive(true);

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
       

    }

 


}
