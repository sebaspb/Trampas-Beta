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

    public bool TieneSonido;

    public GameObject ObjetoConElSonido;
    public AudioClip Sonido;


    public bool DesencadenaSonido;
    bool ControlDesencadenaSonido = false;

    public GameObject ObjetoConElSonidoAjeno;
    public AudioClip SonidoAjeno;

    public GameObject LetraE;

    public bool Destruir;
 
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
        if (Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger==true)
        {
            LetraE.SetActive(true);
        }

        if (Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger==false)
        {
           LetraE.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E)&&Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
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

                if (AnimacionAsignada !=null)
                {

                    if (!SePuedeRepetir && control == 0)
                    {

                        control = 1;
                        PrefabNivel.GetComponent<Animator>().Play(nombre, layer);

                    }

                }

                if (Destruir)
                {
                    StartCoroutine(DestruirBoton(2f));
                }

            }

            else

            {

                Debug.Log("Botón en uso");

            }

        }
        
    }

    IEnumerator DestruirBoton(float time)
    {

        yield return new WaitForSeconds(time);
   

            Destroy(gameObject);


    }
}
