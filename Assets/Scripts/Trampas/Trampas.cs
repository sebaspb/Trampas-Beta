using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{

    bool EstaAbierta = false;

     public GameObject FBX;

    public GameObject Trigger;

    public float tiempo;

    public float tiempoDaño;

    public float Daño;

    public bool tieneSonido = false;

    public bool tieneDelaySonido = false;

    public float DelaySonido;


    Animation Animacion;
    void Start()
    {

        Animacion = FBX.GetComponent<Animation>();
        
    }

    
    void Update()
    {

        if(Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
        {

            if(!EstaAbierta)
            {

                Animacion.Play("AbrirTrampa");
                StartCoroutine(DañoTrampa(tiempoDaño));
                EstaAbierta = true;

                if (tieneSonido)
                {
                    
                    if (!tieneDelaySonido) { 
                    this.GetComponent<AudioSource>().Play();
                    }

                    if (tieneDelaySonido)
                    {
                        StartCoroutine(SonidoConDelay(DelaySonido));
                    }

                }

                if (EstaAbierta) { 

                StartCoroutine(CerrarTrampa(tiempo));
                }

            }

            

        }
        
    }

    IEnumerator CerrarTrampa(float time)
    {

        yield return new WaitForSeconds(time);
        if (tieneSonido)
        {

            this.GetComponent<AudioSource>().Play();

        }
        Animacion.Play("CerrarTrampa");

        if (Animacion.IsPlaying("CerrarTrampa"))
        {
            EstaAbierta = false;
        }

    }

    IEnumerator DañoTrampa(float time)
    {

        yield return new WaitForSeconds(time);
        if(Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
        {

            VariablesJugador.SaludJugador -= Daño;
            Debug.Log(VariablesJugador.SaludJugador);

        }

    }

    IEnumerator SonidoConDelay(float time)
    {

        yield return new WaitForSeconds(time);
        this.GetComponent<AudioSource>().Play();

        

    }

}
