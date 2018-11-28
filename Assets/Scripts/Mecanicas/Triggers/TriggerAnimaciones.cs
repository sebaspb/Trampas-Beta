using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimaciones : MonoBehaviour
{

    public GameObject FBXAAnimar;
    public AnimationClip[] ArrayAnimaciones;
    public AnimationClip AnimacionAsignada;
    string nombre;
    int layer;
    public bool SePuedeRepetir = false;


    // Start is called before the first frame update
    void Start()
    {
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
            int control = 0;

            if (AnimacionAsignada != null)
            {
                if (!SePuedeRepetir && control == 0)
                {

                    control = 1;
                    FBXAAnimar.GetComponent<Animator>().Play(nombre, layer);
                    Destroy(gameObject);
                }
            }
        }

    }
}
