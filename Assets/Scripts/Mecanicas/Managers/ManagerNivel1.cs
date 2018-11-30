using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;

public class ManagerNivel1 : MonoBehaviour
{
    AudioSource AS_Dialogos;
    public AudioClip AC_Bienvenida;

    private void Start()
    {
        AS_Dialogos = GameObject.Find("Dialogos").GetComponent<AudioSource>();

        AS_Dialogos.PlayOneShot(AC_Bienvenida);

    }
    // Update is called once per frame
    void Update()
    {

     
    }
}
