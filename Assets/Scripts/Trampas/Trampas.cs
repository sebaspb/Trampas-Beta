using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{

    bool EstaAbierta = false;

    float vida = 500f;

    float vidaTotal;

    public GameObject FBX;

    public GameObject Trigger;

    public float tiempo;

    public float tiempoDaño;

    public float Daño;

    public bool tieneSonido = false;

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

                if(tieneSonido)
                {

                    this.GetComponent<AudioSource>().Play();

                }
                StartCoroutine(CerrarTrampa(tiempo));

            }

            if(vida <= 0)
            {

                Destroy(GameObject.FindWithTag("Player"));

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

        EstaAbierta = false;
    }

    IEnumerator DañoTrampa(float time)
    {

        yield return new WaitForSeconds(time);
        if(Trigger.GetComponent<RevisionTrigger>().EstaEnTrigger)
        {

            vida -= Daño;
            Debug.Log("vida" + vida);

        }

    }

}
