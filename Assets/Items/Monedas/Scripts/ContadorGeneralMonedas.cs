using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class contadorMonedasGeneral : MonoBehaviour
{
    //Creación de una instancia estática para acceder al contador desde otros scripts
    public static contadorMonedasGeneral instanciaContadorGeneral;

    //Texto en pantalla que mostrará la cantidad de puntos acumulados
    public TextMeshProUGUI contadorMonedas;

    //Variable que almacena el total de monedas recogidas
    public int numeroMonedas = 0;

    private void Awake()
    {
        //Asegurar que solo haya una instancia del contador
        if (instanciaContadorGeneral == null)
        {
            instanciaContadorGeneral = this;
        }
    }

    public void IncrementarMoneda(int m)
    {
        //MI PROPUESTA: Sumar los puntos recibidos al total de monedas
        numeroMonedas += m;

        //MI PROPUESTA: Actualizar la visualización del puntaje en la interfaz de usuario
        contadorMonedas.text = numeroMonedas.ToString();
    }
}
