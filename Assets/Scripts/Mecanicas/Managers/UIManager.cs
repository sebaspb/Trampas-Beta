using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARFC;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Este script se encarga de controlar todo el funcionamiento de la interfaz desde el menú principal, y el de pausa hasta los botones y la pantalla de victoria y derrota.
/// Éste script también se encarga de controlar el volumen de los sonidos y el comportamiento del jugador cuando muere, tiene referencias al FPController de MoeBaker.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("<INTERFAZ>")]
    [Tooltip("Contenedor de todos los objetos del menú")]
    public GameObject ContenedorUI;
    [Tooltip("Menu principañ")]
    public GameObject MenuPrincipal;
    [Tooltip("Menu Pausa")]
    public GameObject MenuPausa;
    [Tooltip("Menu opciones")]
    public GameObject MenuOpciones;
    [Tooltip("Menu Instrucciones")]
    public GameObject MenuInstrucciones;
    [Tooltip("Menu creditos")]
    public GameObject MenuCreditos;
    [Tooltip("Imagen de fono")]
    public GameObject ImagenFondo;
    [Tooltip("Menu gameover")]
    public GameObject MenuGameOver;
    [Tooltip("Menu victoria")]
    public GameObject MenuVictoria;

    [Header("<COMPORTAMIENTOS>")]
    [Tooltip("Variable que define si el fondo debe ocultarse en éste menu o no")]
    public bool OcultarFondo;
    [Tooltip("Variable que define si éste es un menú principal o no")]
    public bool EsMenuPrincipal;
    [Tooltip("Objeto usado para definir al jugador")]
    GameObject Jugador;
    [Tooltip("Variable usada para comprobar si el jugador está muerto o no")]
    bool EstaMuerto;

    [Header("<AUDIO>")]
    [Tooltip("Objeto usado para incluir la música de fondo")]
    GameObject ObjetoMusica;
    [Tooltip("AudioSource de la Música")]
    public AudioSource AS_Musica;
    [Tooltip("Slider usado para controlar el volumen de la música")]
    public Slider SliderMusica;
    [Tooltip("Slider usado para controlar el volumen de los efectos de sonido")]
    public Slider SliderEfectos;

    [Header("<CAMBIO DE ESCENA>")]
    [Tooltip("Escena a la cual se llamará luego de presionar algún botón")]
    Scene escena;
    

    // Start is called before the first frame update
    void Start()
    {


        DontDestroyOnLoad(this.gameObject);
        ObjetoMusica = GameObject.Find("MusicSource");
        AS_Musica = ObjetoMusica.GetComponent<AudioSource>();
        AS_Musica.ignoreListenerVolume = true;


        SliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica");
        SliderEfectos.value = PlayerPrefs.GetFloat("VolumenEfectos");


        Jugador = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {

        escena = SceneManager.GetActiveScene();
        Debug.Log(escena.name);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1.0f)
            {
                Pausa();
            }

        }

        if(GameManager.SaludJugador <= 0 && !EstaMuerto)
        {
            EstaMuerto = true;
            GameOver();
            StartCoroutine(Resurreccion(3f));

        }

        
            if (TriggerFinal.ganaste == true)
            {

            victoria();

            }

            Volumen();
        
    }

        void victoria()

        {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        MenuVictoria.SetActive(true);

        }

    void Volumen()
    {

        AS_Musica.volume = SliderMusica.value;
        AudioListener.volume=SliderEfectos.value;

    }

    void Pausa()

    {

        MenuPausa.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AS_Musica.Pause();
        AudioListener.pause = true;
        Time.timeScale = 0.0f;
        Jugador.GetComponent<FPController>().Constraints.Control = false;


    }

    public void QuitarPausa()
    {

        AS_Musica.Play();
        AudioListener.pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MenuPausa.SetActive(false);
        Time.timeScale = 1.0f;
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

        PlayerPrefs.SetFloat("VolumenMusica", SliderMusica.value);
        PlayerPrefs.SetFloat("VolumenEfectos", SliderEfectos.value);
        Application.Quit();


    }

    public void CambiarEscena(string nombreEscena)
    {
        PlayerPrefs.SetFloat("VolumenMusica", SliderMusica.value);
        PlayerPrefs.SetFloat("VolumenEfectos", SliderEfectos.value);
        SceneManager.LoadScene(nombreEscena);
               

    }
    
    IEnumerator Resurreccion(float time)
    {
        
        yield return new WaitForSeconds(time);
        Jugador.GetComponent<FPController>().enabled = true;
        Jugador.GetComponent<FPController>().Init();
        GameManager.SaludJugador = 500;
        Debug.Log("Te revivi");
        OcultarCanvas();
        EstaMuerto = false;

    }


}


