using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject ContenedorUI;
    public GameObject MenuPrincipal;
    public GameObject MenuPausa;
    public GameObject MenuOpciones;
    public GameObject MenuInstrucciones;
    public GameObject MenuCreditos;
    public GameObject ImagenFondo;
    public bool OcultarFondo;
    public bool EsMenuPrincipal;
    GameObject Jugador;

    Scene escena;
    

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        escena=SceneManager.GetActiveScene();
        Debug.Log(escena.name);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1.0f)
            {
                Pausa();
            }

        }
    }

    void Pausa()

    {

        MenuPausa.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Jugador.GetComponent<FPController>().Constraints.Control = false;


    }

    public void QuitarPausa()
    {

        MenuPausa.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Jugador.GetComponent<FPController>().Constraints.Control = true;


    }

    public void MostrarMenuOpciones()
    {
        OcultarCanvas();
        MenuOpciones.gameObject.SetActive(true);
        

    }

    public void MostrarMenuInstrucciones()
    {
        OcultarCanvas();
        MenuInstrucciones.gameObject.SetActive(true);
        

    }

    public void MostrarMenuCreditos()
    {
        OcultarCanvas();
        MenuCreditos.gameObject.SetActive(true);
        

    }

    public void MostrarMenuPrincipal()
    {
        OcultarCanvas();
        MenuPrincipal.gameObject.SetActive(true);
        

    }

    public void MostrarMenuPausa()
    {
        OcultarCanvas();
        
        if (!EsMenuPrincipal)
        {
            MenuPausa.gameObject.SetActive(true);
        }
        else
        {
            MenuPrincipal.gameObject.SetActive(true);
        }


    }

    public void OcultarCanvas()
    {

        for (int i = 0; i < ContenedorUI.transform.childCount; i++)
        {
            var child = ContenedorUI.transform.GetChild(i).gameObject;
            if (child != null)
                child.gameObject.SetActive(false);
        }

        if (!OcultarFondo)
        {
            ImagenFondo.SetActive(true);
        }

    }

    public void Salir()
    {

        Application.Quit();

    }

    public void CambiarEscena(string nombreEscena)
    {

        SceneManager.LoadScene(nombreEscena);
               

    }
}
