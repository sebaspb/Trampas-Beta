using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// En éste script se controla el funcionamiento de las palanca de pared y sus variantes.
/// Datos importantes: El array de las animaciones funciona en conjunto a la variable asignada y al nombre y la capa de animación para encontrar la animación
/// correspondiente en el animador del nivel asignado y así reproducir la animación correspondiente, es importante notar que en el animador cada animación debe
/// estar en su propia capa la cual debe tener un *weight* de 1 y un modo aditivo.
/// 
/// Es importante que los sonidos asignados no estén directamente en el botón por ello se pide la referencia al objeto con el sonido que se va a desencadenar, la razón
/// es que el sonido en caso de moverse, debe moverse con dicho objeto, lo cual se logra al emparentarlo, si se colocara en el botón dicho sonido no tendría
/// espacialización tal y como fue diseñado
/// 
/// Los dialogos asignados siempre se reproduciran en el mismo audiosource.
/// 
/// </summary>

public class PalancaDePared : MonoBehaviour
{

    [Header("<Palanca>")]
    [Tooltip("FBX Original del botón")]
    public GameObject FBXoriginal;
    [Tooltip("Trigger que se usará para comprobar si el botón puede activarse o no")]
    public GameObject Trigger;
    [Tooltip("Prefab del nivel al cual hará referencia éste botón")]
    public GameObject PrefabNivel;
    

    [Header("<ANIMACION>")]
    [Tooltip("Animación asignada a éste botón")]
    public AnimationClip AnimacionAsignada;
    [Tooltip("Define si la animación se puede repetir o no")]
    public bool SePuedeRepetir = false;
    [Tooltip("Nombre de la animación a reproducir")]
    string nombre;
    [Tooltip("Capa de la animación a reproducir")]
    int layer;
    [Tooltip("Animación de la palanca")]
    Animation AnimacionBoton;
    [Tooltip("Array de animaciones a revisar")]
    public AnimationClip[] ArrayAnimaciones;
    [Tooltip("Variable de control usada para que la palanca solo pueda activarse una vez")]
    public bool activada = false;

    [Header("<SONIDO>")]
    [Tooltip("Define si el boton tiene sonido o no")]
    public bool TieneSonido;

    [Tooltip("Objeto el cual tiene el sonido a reproducir al presionar el boton")]
    public GameObject ObjetoConElSonido;
    [Tooltip("AudioClip a reproducir")]
    public AudioClip Sonido;

    [Tooltip("Define si éste botón desencadena un sonido al ser presionado")]
    public bool DesencadenaSonido;
    [Tooltip("Variable de control para que el sonido sólo se reproduzca una vez")]
    bool ControlDesencadenaSonido = false;

    [Tooltip("En caso de desencadenar un sonido de otro objeto debe seleccionarse en éste campo")]
    public GameObject ObjetoConElSonidoAjeno;
    [Tooltip("Clip para el sonido anterior")]
    public AudioClip SonidoAjeno;

    [Header("<DIALOGO>")]
    [Tooltip("variable para confirmar si la palanca desencadena un diálogo al momento de ser activada")]
    public bool TIeneDialogo = false;
    [Tooltip("Audiosource en el cual se reproducirá el diálogo")]
    AudioSource AS_Dialogos;
    [Tooltip("Dialogo que se reproducirá")]
    public AudioClip Dialogo;

    [Header("<INTERFAZ>")]
    [Tooltip("Objeto usado para mostrar la letra E cuando se puede interactuar con un botón")]
    public GameObject LetraE;

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
        if (Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger == true)
        {

            LetraE.SetActive(true);

        }

        if (Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger == false)
        {

            LetraE.SetActive(false);

        }

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

                //Debug.Log("Botón en uso");

            }

        }

    }
}
