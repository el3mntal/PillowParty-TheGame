using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalificacionFinal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoPuntuacionFinal;

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += MostrarLetraFinal;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= MostrarLetraFinal;
    }

    public void MostrarLetraFinal()
    {

        int puntos = PlayerPrefs.GetInt("PuntuacionFinal", 0); //--COPILOT (Recuperar puntuación)
        textoPuntuacionFinal.text = DeterminarLetra(puntos);

        /*
        contadorMonedasGeneral contadorGeneral = FindObjectOfType<contadorMonedasGeneral>();
                if (contadorGeneral != null)
                {
                    string letraFinal = DeterminarLetra(contadorGeneral.numeroMonedas);
                    textoPuntuacionFinal.text = letraFinal;
                }
            }
            */

        //COPILOT: Método para asignar la letra según la puntuación
        string DeterminarLetra(int puntos)
        {
            if (puntos >= 75)
                return "S";
            else if (puntos >= 60)
                return "B";
            else if (puntos >= 30)
                return "F";
            else
                return ":("; // Si no alcanza los 10 puntos, muestra un guion o cualquier otra indicación

        }
    }
}
