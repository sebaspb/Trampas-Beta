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
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (VariablesJugador.SaludJugador<=0 && GameManager.IDNivelActual==4){
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
