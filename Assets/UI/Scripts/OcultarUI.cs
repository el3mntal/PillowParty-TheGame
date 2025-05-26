using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasInterfazGrafica; // Referencia directa al Canvas de la Interfaz //--copilot--

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += Desactivar;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= Desactivar;
    }

    private void Desactivar()
    {
        if (canvasInterfazGrafica != null) //--copilot--
        {
            canvasInterfazGrafica.SetActive(false); //--copilot--
        }
        else
        {
            Debug.LogWarning("No se encontró la referencia a InterfazGrafica."); //--copilot--
        }
    }
}
