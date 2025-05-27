using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Reintentar el juego
    public void ReiniciarJuego()
    {
        contadorMonedasGeneral contadorGeneral = FindObjectOfType<contadorMonedasGeneral>();
        if (contadorGeneral != null)
        {
            PlayerPrefs.SetInt("PuntuacionFinal", contadorGeneral.numeroMonedas);
        }


        SceneManager.LoadScene(1);
    }

    // Volver al menu
    public void VolverMenu()
    {
        SceneManager.LoadScene(0);
    }
}
