using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarImagenUI : MonoBehaviour
{
    [SerializeField] private GameObject[] canvasObjetivos; // Array de Canvas que serán desactivados //--copilot--

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += DesactivarCanvas;
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= DesactivarCanvas;
    }

    private void DesactivarCanvas()
    {
        if (canvasObjetivos.Length > 0) //--copilot--
        {
            foreach (GameObject canvas in canvasObjetivos) //--copilot--
            {
                if (canvas != null)
                {
                    canvas.SetActive(false); //--copilot--
                    Debug.Log($"Canvas {canvas.name} desactivado."); //--copilot--
                }
            }
        }
        else
        {
            Debug.LogWarning("No se han asignado Canvas en el Inspector."); //--copilot--
        }
    }
}
