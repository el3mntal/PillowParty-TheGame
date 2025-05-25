using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OcultarTitulosPuntajeFinal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] titulos; // Array con los títulos que se mostrarán

    private void Awake()
    {
        // Ocultar todos los títulos al inicio
        foreach (var titulo in titulos)
        {
            titulo.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += MostrarTitulosAlFinalizar;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= MostrarTitulosAlFinalizar;
    }

    private void MostrarTitulosAlFinalizar()
    {
        // Activar todos los títulos cuando el temporizador llegue a 0
        foreach (var titulo in titulos)
        {
            titulo.gameObject.SetActive(true);
        }
    }
}
