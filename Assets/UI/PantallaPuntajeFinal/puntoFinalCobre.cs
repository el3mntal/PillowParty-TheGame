using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puntoFinalCobre : MonoBehaviour
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
        ContadorMonedasIndividuales contadorIndividual = FindObjectOfType<ContadorMonedasIndividuales>();
        if (contadorIndividual != null)
        {
            textoPuntajeFinal.text = string.Format("{0:D2}", contadorIndividual.monedasCobre);
        }
    }
}
