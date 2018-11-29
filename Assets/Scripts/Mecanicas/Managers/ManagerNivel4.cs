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

                 if (ControlPalancas == 6)
        {
            PisoTrampa.GetComponent<MeshCollider>().enabled = false;
        }       

        
        if (ControlPalancas >= 8 && TriggerPuertaObjetivo !=null)
        {

            TriggerPuertaObjetivo.SetActive(true);


        }
        
    }

    void ReiniciarJugador()
    {
      
        //Jugador.transform.position = Spawn.transform.position;
        //Jugador.transform.rotation = Spawn.transform.rotation;



    }

 


}
