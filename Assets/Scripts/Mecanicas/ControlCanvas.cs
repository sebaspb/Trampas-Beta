using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ARFC;

public class ControlCanvas : MonoBehaviour
{
    public GameObject PausaMenu;

	public Button Continuar;

    void Start ()
	{


    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{

			Pausa();
			
		}
	}

	public void CargarScena(int i)
	{

		SceneManager.LoadScene(i);

	}

   

	public void ActivarCanvas(GameObject canvasActivado)
	{

		canvasActivado.SetActive(true);

	}

	public void DesactivarCanvas(GameObject canvasDesactivado)
	{
		canvasDesactivado.SetActive(false);
	}

	public void Pausa()
    {	
		if (Time.timeScale == 1.0f )
        {
			PausaMenu.SetActive(true);
            Time.timeScale = 0.0f;
			
	        GameObject.FindWithTag("Player").GetComponent<FPController>().Constraints.Control = false;
    
        }
	}

	public void QuitarPausar()
	{
		if(Time.timeScale == 0.0f)
		{

			Time.timeScale = 1.0f;
			GameObject.FindWithTag("Player").GetComponent<FPController>().Constraints.Control = true;

		}

	}

	public void QuitarJuego()
	{
		Application.Quit();
	}
}
