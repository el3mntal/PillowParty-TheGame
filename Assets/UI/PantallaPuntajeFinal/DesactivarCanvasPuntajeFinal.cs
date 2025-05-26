using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCanvasPuntajeFinal : MonoBehaviour
{
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
    }
}
