using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAutomaticoPlata : MonoBehaviour
{
    public float velocidad = 30.0f; // Velocidad de movimiento
    public float limiteDerecha = -230f; // Límite derecho en el eje Z
    public float limiteIzquierda = -306f; // Límite izquierdo en el eje Z

    private int direccion = 1; // 1 para derecha, -1 para izquierda


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * direccion * velocidad * Time.deltaTime;

        if (transform.position.z >= limiteDerecha)
        {
            direccion = -1; // Cambia dirección a izquierda
        }
        else if (transform.position.z <= limiteIzquierda)
        {
            direccion = 1; // Cambia dirección a derecha
        }
    }
}
