using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAutomaticoCobre : MonoBehaviour
{
    public float velocidad = 15.0f; // Velocidad de movimiento
    public float limiteArriba = 280f; // Límite superior en el eje Y
    public float limiteAbajo = 250f; // Límite inferior en el eje Y

    private int direccion = 1; // 1 para arriba, -1 para abajo

    void Update()
    {
        transform.position += Vector3.up * direccion * velocidad * Time.deltaTime;

        if (transform.position.y >= limiteArriba)
        {
            direccion = -1; // Cambia dirección hacia abajo
        }
        else if (transform.position.y <= limiteAbajo)
        {
            direccion = 1; // Cambia dirección hacia arriba
        }
    }
}
