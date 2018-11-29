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


        }

        if (ControlMuertes!=0 && TriggerSubirTecho != null)
        {

            TriggerSubirTecho.SetActive(true);

        }
        
    }

    void ReiniciarJugador()
    {
        
        //Jugador.transform.position = Spawn.transform.position;
        //Jugador.transform.rotation = Spawn.transform.rotation;
       
     


    }

 


}
