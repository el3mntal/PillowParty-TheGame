using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescripcionCalificacionPuntaje : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDescripcionFinal;

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += MostrarDescripcionFinal;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= MostrarDescripcionFinal;
    }

    public void MostrarDescripcionFinal()
    {
        int puntos = PlayerPrefs.GetInt("PuntuacionFinal", 0); //--COPILOT (Recuperar puntuación)
        textoDescripcionFinal.text = DeterminarDescripcion(puntos);

        /*
        contadorMonedasGeneral contadorGeneral = FindObjectOfType<contadorMonedasGeneral>();

        if (contadorGeneral != null)
        {
            string descripcionFinal = DeterminarDescripcion(contadorGeneral.numeroMonedas);
            textoDescripcionFinal.text = descripcionFinal;
        }
        */
    }

    //COPILOT: Método para asignar la descripción según la puntuación
    string DeterminarDescripcion(int puntos)
    {
        if (puntos >= 30)
            return "¡Puntuación Perfecta!";
        else if (puntos >= 20)
            return "Nada mal, aprendes rápido.";
        else if (puntos >= 10)
            return "¡Vamos! puedes hacerlo mejor.";
        else
            return "Sigue intentándolo, ¡tú puedes!";
    }
}
