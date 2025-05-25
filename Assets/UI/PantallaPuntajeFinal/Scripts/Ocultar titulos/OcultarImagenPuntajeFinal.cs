using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarImagenPuntajeFinal : MonoBehaviour
{
    [SerializeField] GameObject[] imagenes; // Array con las imágenes dentro del Object Empty

    private void Awake()
    {
        // Ocultar todas las imágenes al inicio
        foreach (var imagen in imagenes)
        {
            imagen.SetActive(false);
        }
    }

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += MostrarImagenesAlFinalizar;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= MostrarImagenesAlFinalizar;
    }

    private void MostrarImagenesAlFinalizar()
    {
        // Activar todas las imágenes cuando el temporizador llegue a 0
        foreach (var imagen in imagenes)
        {
            imagen.SetActive(true);
        }
    }
}
