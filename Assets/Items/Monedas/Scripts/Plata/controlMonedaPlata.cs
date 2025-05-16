using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMonedaPlata : MonoBehaviour
{
    private float velocidadRotacionMoneda = 80f;
    private float esperaReaparecerMoneda = 5f;
    private Vector3 antiguaPosicionMoneda;
    private Animator animacionMoneda;

    void Start()
    {
        animacionMoneda = this.GetComponent<Animator>();
        antiguaPosicionMoneda = transform.localPosition; // Guardar la posición local
        //antiguaPosicionMoneda = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, velocidadRotacionMoneda * Time.deltaTime, 0);
    }
    //ejecucion de metodo de desaparecer moneda tras una colision
    private void OnTriggerEnter(Collider other)
    {
        //comprobacion de colision unicamente con objeto con tag Player
        if (other.CompareTag("Player"))
        {
            //llamado del script ContadorMoneda por medio de su instancia para ejecutar el metodo incrementar moneda
            contadorMonedasGeneral.instanciaContadorGeneral.IncrementarMoneda(5);

            // Desactivar la moneda y pedir al administrador que la reaparezca
            this.gameObject.SetActive(false);

            //llamado del script CorrutinaMoneda por medio de sus instancia para ejecutar el metodo ReaparecerMoneda para
            corrutinaMonedaPlata.instanciaCorrutinaMoneda.ReaparecerMoneda(this.gameObject, antiguaPosicionMoneda, esperaReaparecerMoneda);
        }
    }
}