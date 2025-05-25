using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeFinalJuego : MonoBehaviour
{
    [SerializeField] Text mensajeFinal;

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += MostrarMensajeFinal;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= MostrarMensajeFinal;
    }

    void MostrarMensajeFinal()
    {
        mensajeFinal.text = "FINALIZÓ EL JUEGO";
    }
}

