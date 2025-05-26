using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCanvasPuntajeFinal : MonoBehaviour
{
    [SerializeField] private GameObject canvasMostrar; // Primer Canvas que se muestra cuando el temporizador llega a 0
    [SerializeField] private GameObject canvasOcultar; // Segundo Canvas que se oculta cuando el temporizador llega a 0
    [SerializeField] private GameObject temporizadorObj; // GameObject con el script ControlTemporizador

    private ControlTemporizador temporizador;

    private void Start()
    {
        if (temporizadorObj != null)
        {
            temporizador = temporizadorObj.GetComponent<ControlTemporizador>();
        }
    }

    private void Update()
    {
        if (temporizador != null)
        {
            bool tiempoFinalizado = temporizador.RestanteTiempo <= 0;

            // Mostrar el primer Canvas cuando el tiempo es 0
            canvasMostrar.SetActive(tiempoFinalizado);

            // Ocultar el segundo Canvas cuando el tiempo es 0
            canvasOcultar.SetActive(!tiempoFinalizado);
        }
    }


    /*
    [SerializeField] private GameObject canvas; // Referencia al Canvas
    [SerializeField] private GameObject temporizadorObj; // Referencia al GameObject con el script

    private ControlTemporizador temporizador;

    private void Start()
    {
        if (temporizadorObj != null)
        {
            temporizador = temporizadorObj.GetComponent<ControlTemporizador>();
        }
    }

    private void Update()
    {
        if (temporizador != null)
        {
            // Mostrar Canvas cuando el tiempo es 0, ocultarlo si es mayor a 0
            canvas.SetActive(temporizador.RestanteTiempo <= 0);
        }
    }*/
}
