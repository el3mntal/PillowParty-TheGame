using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //metodo para cargar la escena del juego
    public void BotonJugar()
	{
	    SceneManager.LoadScene(1);
	}

    //metodo para cerrar la aplicacion 
    public void BotonSalir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego, esperamos que vuelvas pronto");
    }
}
