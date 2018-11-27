using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesJugador : MonoBehaviour
{
    [SerializeField]
    public static float SaludJugador = 500f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SaludJugador <= 0)
        {
            Debug.Log("Has muerto");
        }

    }
}
