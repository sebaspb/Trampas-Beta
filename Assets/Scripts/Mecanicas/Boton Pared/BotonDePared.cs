using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BotonDePared : MonoBehaviour
{

    
    public GameObject FBXoriginal;
    public GameObject Trigger;
    public GameObject PrefabNivel;
    public AnimationClip AnimacionAsignada;
    public bool SePuedeRepetir = false;
    string nombre;
    int layer;
    Animation AnimacionBoton;
    public AnimationClip[] ArrayAnimaciones;

    // Start is called before the first frame update
    void Start()
    {
        AnimacionBoton = FBXoriginal.GetComponent<Animation>();

        for (int i = 0; i < ArrayAnimaciones.Length; i++)
        {
            if (AnimacionAsignada == ArrayAnimaciones[i])
            {
                nombre = AnimacionAsignada.name;
                layer = i;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)&&Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
        {

            if (!AnimacionBoton.IsPlaying("Accionar Boton"))
            {
                int control = 0;
                AnimacionBoton.Play("Accionar Boton");

                if (AnimacionAsignada !=null)
                {

                    if (!SePuedeRepetir && control == 0)
                    {

                        control = 1;
                        PrefabNivel.GetComponent<Animator>().Play(nombre, layer);

                    }

                }

            }

            else

            {

                Debug.Log("Botón en uso");

            }

        }
        
    }
}
