using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
//using UnityEditor.Animations;


public class PalancaDePared : MonoBehaviour
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
    public bool activada = false;

    public bool TieneSonido;

    public GameObject ObjetoConElSonido;
    public AudioClip Sonido;

    public bool DesencadenaSonido;
    bool ControlDesencadenaSonido = false;

    public GameObject ObjetoConElSonidoAjeno;
    public AudioClip SonidoAjeno;
    public bool TIeneDialogo = false;

    AudioSource AS_Dialogos;
    public AudioClip Dialogo;

    // Start is called before the first frame update
    void Start()
    {
         AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();

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

        if (Input.GetKeyDown(KeyCode.E) && Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger && activada == false)
        {
          

            if (!AnimacionBoton.IsPlaying("Accionar Boton"))
            {
                int control = 0;
                AnimacionBoton.Play("Accionar Boton");
                if (TieneSonido)
                {
                    ObjetoConElSonido.GetComponent<AudioSource>().PlayOneShot(Sonido);
                }

                if (DesencadenaSonido && !ControlDesencadenaSonido)
                {
                    ObjetoConElSonidoAjeno.GetComponent<AudioSource>().PlayOneShot(SonidoAjeno);
                    ControlDesencadenaSonido = true;
                }

                  

                activada = true;

                if (AnimacionAsignada != null)
                {

                    if (!SePuedeRepetir && control == 0)
                    {

                        control = 1;
                        PrefabNivel.GetComponent<Animator>().Play(nombre, layer);
 if(TIeneDialogo)
                    {

                        AS_Dialogos.clip = Dialogo;
                        AS_Dialogos.Play();

                    }
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
