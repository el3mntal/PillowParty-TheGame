using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAutomaticoOro : MonoBehaviour
{
    public float velocidad = 50.0f; // Velocidad de movimiento
    public float limiteDerecha = -60f; // Límite derecho en el eje Z
    public float limiteIzquierda = -300f; // Límite izquierdo en el eje Z

    private int direccion = 1; // 1 para derecha, -1 para izquierda

    private bool detenerMovimiento = false; //---C---

    private void OnEnable()
    {
        ControlTemporizador.OnTemporizadorFinalizado += DetenerMovimiento; //---C---
    }

    private void OnDisable()
    {
        ControlTemporizador.OnTemporizadorFinalizado -= DetenerMovimiento; //---C---
    }

    private void DetenerMovimiento()
    {
        detenerMovimiento = true; //---C---
    }

    // Update is called once per frame
    void Update()
    {

        if (detenerMovimiento) return; //---C---
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
