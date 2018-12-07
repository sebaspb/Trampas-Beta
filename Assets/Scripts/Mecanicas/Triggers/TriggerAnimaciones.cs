using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Este script se utliza para desencadenar animaciones específicas en caso de que el jugador pase por el trigger correspondiente
/// 
///  Datos importantes: El array de las animaciones funciona en conjunto a la variable asignada y al nombre y la capa de animación para encontrar la animación
/// correspondiente en el animador del nivel asignado y así reproducir la animación correspondiente, es importante notar que en el animador cada animación debe
/// estar en su propia capa la cual debe tener un *weight* de 1 y un modo aditivo.
/// 
/// Es importante que los sonidos asignados no estén directamente en el trigger por ello se pide la referencia al objeto con el sonido que se va a desencadenar, la razón
/// es que el sonido en caso de moverse, debe moverse con dicho objeto, lo cual se logra al emparentarlo, si se colocara en el trigger dicho sonido no tendría
/// espacialización tal y como fue diseñado
/// </summary>
public class TriggerAnimaciones : MonoBehaviour
{
    [Header("<ANIMACION>")]
    [Tooltip("Objeto que se animará")]
    public GameObject FBXAAnimar;
    [Tooltip("Array de animaciones a revisar")]
    public AnimationClip[] ArrayAnimaciones;
    [Tooltip("Animación asignada al trigger")]
    public AnimationClip AnimacionAsignada;
    [Tooltip("Nombre de la animación a reproducir")]
    string nombre;
    [Tooltip("Capa de la animación a reproducir")]
    int layer;
    [Tooltip("Define si la animación puede repetirse o no")]
    public bool SePuedeRepetir = false;

    [Header("<SONIDO>")]
    [Tooltip("Define si la animación tiene un sonido asignado o no")]
    public bool TieneSonido;
    [Tooltip("Objeto el cual tiene el sonido a reproducir al presionar el boton")]
    public GameObject ObjetoConElSonido;
    [Tooltip("AudioClip a reproducir")]
    public AudioClip Sonido;

    [Header("<COMPORTAMIENTO>")]
    [Tooltip("Define si el sonido es constante o no")]
    public bool EsConstante;
        [Tooltip("Define si el trigger desactiva un objeto o no")]
    public bool DesactivaObjeto;
    [Tooltip("Objeto a desactivar")]
    public GameObject ObjetoADesactivar;

    [Header("<DIALOGOS>")]
    [Tooltip("Define si el trigger tiene diálogo o no")]
    public bool TIeneDialogo = false;
    [Tooltip("Audiosource para el diálogo")]
    AudioSource AS_Dialogos;
    [Tooltip("Diálogo a reproducir.")]
    public AudioClip Dialogo;

    // Start is called before the first frame update
    void Start()
    {

        AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();

        for (int i = 0; i < ArrayAnimaciones.Length; i++)
        {

            if (AnimacionAsignada == ArrayAnimaciones[i])
            {
                nombre = AnimacionAsignada.name;
                layer = i;
            }

        }
    }



    private void OnTriggerEnter(Collider other)
    {
                  
        if (other.CompareTag("Player"))
        {
            if (TIeneDialogo)
            {

                AS_Dialogos.PlayOneShot(Dialogo);
                Destroy(gameObject);

            }

            int control = 0;

            if (AnimacionAsignada != null)
            {

                if (!SePuedeRepetir && control == 0)
                {

                    control = 1;
                    FBXAAnimar.GetComponent<Animator>().Play(nombre, layer);

                    if (TieneSonido)
                    {

                        if (!EsConstante)
                        { 

                            ObjetoConElSonido.GetComponent<AudioSource>().PlayOneShot(Sonido);

                        }

                        if (EsConstante)
                        {

                            ObjetoConElSonido.GetComponent<AudioSource>().Play();

                        }

                        if (DesactivaObjeto)
                        {

                            ObjetoADesactivar.SetActive(false);

                        }
                    }

                    Destroy(gameObject);

                }
            }
        }

    }
}
