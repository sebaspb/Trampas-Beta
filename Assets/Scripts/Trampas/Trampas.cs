using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Éste script controla el comportamiento de las trampas que por lo general no son letales, es importante notar que el tiempo de daño y el tiempo hacen referencia a la duraciónd de la animación para que todo quede
/// bien sincronizado.
/// 
/// Es importante aclarar que a diferencia de las animaciones de los niveles las de las trampas fueron separadas en Unity y el sistema usado para exportar las animaciones desde blender es diferente, razón por la cual
/// las animaciones en éste caso se referencian con el nombre y no con capas en un animador.
/// 
/// </summary>
public class Trampas : MonoBehaviour
{
    [Header("<TRAMPA>")]
    [Tooltip("Variable que comprueba si la trampa está abierta o activada")]
    bool EstaAbierta = false;
    [Tooltip("FBX original de la trampa")]
    public GameObject FBX;
    [Tooltip("Trigger que se usará para activar la trampa")]
    public GameObject Trigger;
    [Tooltip("Tiempo que pasará antes de que la trampa se cierre/desactive luego de ser abierta/activada")]
    public float tiempo;

    [Header("<DAÑO>")]
    [Tooltip("Tiempo que pasará antes de que la trampa cause daño")]
    public float tiempoDaño;
    [Tooltip("Daño causado por la trampa")]
    public float Daño;

    [Header("<SONIDO>")]
    [Tooltip("Variable que comprueba si la trampa tiene sonido asignado o no")]
    public bool tieneSonido = false;
    [Tooltip("Variable que comprueba si la el sonido activado tiene delay antes de reproducirse")]
    public bool tieneDelaySonido = false;
    [Tooltip("Delay usado para activar el sonido de la trampa")]
    public float DelaySonido;

    [Header("<ANIMACION>")]
    [Tooltip("Animación de la trampa")]
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
                    
                    if (!tieneDelaySonido)
                    { 

                        this.GetComponent<AudioSource>().Play();

                    }

                    if (tieneDelaySonido)
                    {

                        StartCoroutine(SonidoConDelay(DelaySonido));

                    }

                }

                if (EstaAbierta)
                { 

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

            GameManager.SaludJugador -= Daño;
           
        }

    }

    IEnumerator SonidoConDelay(float time)
    {

        yield return new WaitForSeconds(time);
        this.GetComponent<AudioSource>().Play();

        
    }

}
