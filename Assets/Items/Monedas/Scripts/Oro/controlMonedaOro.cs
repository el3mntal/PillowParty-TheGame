using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMonedaOro : MonoBehaviour
{
    private float velocidadRotacionMoneda = 80f;
    private float esperaReaparecerMoneda = 10f;
    private Vector3 antiguaPosicionMoneda;
    private Animator animacionMoneda;


    // Referencia al AudioSource del Object Empty //--copilot--
    private AudioSource audioSource;

    public AudioClip sonidoMoneda; // Agrega un AudioClip en el Inspector de Unity //--copilot--
    void Start()
    {
        animacionMoneda = this.GetComponent<Animator>();
        antiguaPosicionMoneda = transform.localPosition;
        //antiguaPosicionMoneda = transform.position;


        // Encuentra el AudioSource dentro del Object Empty (padre) //--copilot--
        audioSource = GetComponentInParent<AudioSource>();
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
            // Reproducir sonido de la moneda //--copilot--
            if (audioSource != null && sonidoMoneda != null)
            {
                audioSource.PlayOneShot(sonidoMoneda); //--copilot--
            }



            //COPILOT: Obtener el script del personaje y aumentar su contador de plata
            ContadorMonedasIndividuales contadorIndividual = other.GetComponent<ContadorMonedasIndividuales>();
            if (contadorIndividual != null)
            {
                contadorIndividual.IncrementarMoneda("Plata");
            }
            /*
                //COPILOT: Obtener el script del personaje y aumentar su contador de cobre
                ContadorMonedasIndividuales contadorIndividual = other.GetComponent<ContadorMonedasIndividuales>();
                if (contadorIndividual != null)
                {
                    contadorIndividual.IncrementarMoneda(gameObject.tag); // Usa el tag como identificador
                }
    */


            //llamado del script ContadorMoneda por medio de su instancia para ejecutar el metodo incrementar moneda
            contadorMonedasGeneral.instanciaContadorGeneral.IncrementarMoneda(5);

            // Desactivar la moneda y pedir al administrador que la reaparezca
            this.gameObject.SetActive(false);

            //llamado del script CorrutinaMoneda por medio de sus instancia para ejecutar el metodo ReaparecerMoneda para
            corrutinaMonedaOro.instanciaCorrutinaMoneda.ReaparecerMoneda(this.gameObject, antiguaPosicionMoneda, esperaReaparecerMoneda);
        }
    }
}