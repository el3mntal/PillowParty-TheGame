using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCanvasPuntajeFinal : MonoBehaviour
{
    [SerializeField] private GameObject canvasMostrar; // Canvas a mostrar cuando el temporizador llega a 0
    [SerializeField] private GameObject canvasOcultar; // Canvas a ocultar cuando el temporizador llega a 0
    [SerializeField] private GameObject temporizadorObj; // GameObject con el script ControlTemporizador

    private ControlTemporizador temporizador;
    private CalificacionFinal calificacionFinal; //--COPILOT (Referencia a CalificacionFinal)
    private DescripcionCalificacionPuntaje descripcionPuntaje; //--COPILOT (Referencia a DescripcionCalificacionPuntaje)

    private puntoFinalCobre puntajeCobre; //--COPILOT (Referencia a puntoFinalCobre)
    private puntoFinalPlata puntajePlata; //--COPILOT (Referencia a puntoFinalPlata)
    private puntoFinalOro puntajeOro; //--COPILOT (Referencia a puntoFinalOro)

    private void Start()
    {
        if (temporizadorObj != null)
        {
            temporizador = temporizadorObj.GetComponent<ControlTemporizador>();
        }

        // Buscar los componentes de puntuación y descripción en la escena
        calificacionFinal = FindObjectOfType<CalificacionFinal>(); //--COPILOT
        descripcionPuntaje = FindObjectOfType<DescripcionCalificacionPuntaje>(); //--COPILOT

        // Buscar los objetos de puntaje en la escena
        puntajeCobre = FindObjectOfType<puntoFinalCobre>(); //--COPILOT
        puntajePlata = FindObjectOfType<puntoFinalPlata>(); //--COPILOT
        puntajeOro = FindObjectOfType<puntoFinalOro>(); //--COPILOT
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

            // Actualizar la puntuación y descripción cuando el tiempo llega a 0
            if (tiempoFinalizado)
            {
                calificacionFinal?.MostrarLetraFinal(); //--COPILOT (Actualizar calificación)
                descripcionPuntaje?.MostrarDescripcionFinal(); //--COPILOT (Actualizar descripción)

                puntajeCobre?.ActualizarTextoFinal(); //--COPILOT (Actualizar puntaje cobre)
                puntajePlata?.ActualizarTextoFinal(); //--COPILOT (Actualizar puntaje plata)
                puntajeOro?.ActualizarTextoFinal(); //--COPILOT (Actualizar puntaje oro)
            }
        }
    }
    /*
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
*/

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
