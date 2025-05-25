using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TituloContadorIndividual : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoPuntajeFinal;

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += ActualizarTextoFinal;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= ActualizarTextoFinal;
    }

    void ActualizarTextoFinal()
    {
        //COPILOT: Obtener el script de contadores individuales en el jugador
        ContadorMonedasIndividuales contadorIndividual = FindObjectOfType<ContadorMonedasIndividuales>();

        if (contadorIndividual != null)
        {
            //COPILOT: Formatear el texto con los puntajes
            textoPuntajeFinal.text = string.Format("{0:D2} {1:D2} {2:D2}",
                contadorIndividual.monedasCobre,
                contadorIndividual.monedasPlata,
                contadorIndividual.monedasOro);
        }
    }
}
