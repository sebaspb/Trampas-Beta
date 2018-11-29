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
    public GameObject MenuGameOver;
    public bool OcultarFondo;
    public bool EsMenuPrincipal;
    GameObject Jugador;
    bool EstaMuerto;

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

        if(VariablesJugador.SaludJugador <= 0 && !EstaMuerto)
        {
            EstaMuerto = true;
            GameOver();
            StartCoroutine(Resurreccion(3f));

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
    public void GameOver()
    {
        Jugador.GetComponent<FPController>().initilized = false;
        Jugador.GetComponent<FPController>().enabled = false;
        Debug.Log("Perdiste wey");
        MenuGameOver.SetActive(true);
        Jugador.transform.position = GameManager.SpawnActual.transform.position;
        Jugador.transform.rotation = GameManager.SpawnActual.transform.rotation;

    }



    public void OcultarCanvas()
    {

        for (int i = 0; i < ContenedorUI.transform.childCount; i++)
        {
            var child = ContenedorUI.transform.GetChild(i).gameObject;
            if (child != null)
                child.gameObject.SetActive(false);
        }

        if (!OcultarFondo && ImagenFondo!=null)
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
    
    IEnumerator Resurreccion(float time)
    {
        
        yield return new WaitForSeconds(time);
        Jugador.GetComponent<FPController>().enabled = true;
        Jugador.GetComponent<FPController>().Init();
        VariablesJugador.SaludJugador = 500;
        Debug.Log("Te revivi");
        OcultarCanvas();
        EstaMuerto = false;

    }


}


