using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class controlPersonaje : MonoBehaviour
{
    //PERSONAJE
    private Animator animacionPersonaje;
    private float velocidad = 50f;
    private float inputHorizontal;
    private Quaternion rotacionPersonaje;
    private CharacterController controladorPersonaje;
    private Vector3 movimientoDireccion;
    private float gravedad = 100f;
    //variable para acceder al script de MenuPausa
    public MenuPausa PausaC;

    //Trampolin
    private float fuerzaTrampolin = 250f;

    //CongelarPersonaje
    private bool congelado = false; //--C-- Nueva variable para congelar el personaje cuando el temporizador llegue a cero.


    // Start is called before the first frame update
    void Start()
    {
        animacionPersonaje = this.GetComponent<Animator>();
        controladorPersonaje = this.GetComponent<CharacterController>();

        //Restriccion de FPS
        Application.targetFrameRate = 30;

        // Suscribirse al evento de temporizador
        ControlTemporizador.OnTemporizadorFinalizado += CongelarPersonaje; //--C--
    }

    // Update is called once per frame
    void Update()
    {
        if (!congelado) //--C-- Si el personaje no está congelado, permitir movimiento.
        {
            MoverPersonaje();
        }
    }

    //Metodo Personaje
    void MoverPersonaje()
    {
        if (PausaC.Pausa || congelado) //--C-- Verificar si el juego está en pausa o congelado.
        {
            return;
        }

        //condicional para detener el personaje
        if (PausaC.Pausa == true)
        {
            return;
        }

        inputHorizontal = Input.GetAxisRaw("Horizontal");

        movimientoDireccion.z = inputHorizontal * velocidad;

        //verificacion contacto con el suelo (isGrounded)
        if (controladorPersonaje.isGrounded)
        {
            animacionPersonaje.SetBool("Aterrizar", true);
        }
        else
        {
            movimientoDireccion.y -= gravedad * Time.deltaTime;
        }
        if (inputHorizontal != 0)
        {
            rotacionPersonaje = Quaternion.LookRotation(new Vector3(0, 0, inputHorizontal));
            this.transform.rotation = rotacionPersonaje;
            //animacionPersonaje.SetBool("Aterrizar", false);
        }

        if (controladorPersonaje.isGrounded && inputHorizontal != 0)
        {
            animacionPersonaje.SetBool("Aterrizar", true);
        }

        controladorPersonaje.Move(movimientoDireccion * Time.deltaTime);

        //LIMITACION DE PERSONAJE
        Vector3 posicionRestringida = transform.position;
        posicionRestringida.z = Mathf.Clamp(posicionRestringida.z, -333f, 333f);
        posicionRestringida.y = Mathf.Clamp(posicionRestringida.y, 155f, 516f);
        transform.position = posicionRestringida;

        Debug.Log("Ejecucion del movimeinto horizontal");
    }

    //TRAMPOLIN
    //Metodo de Colision con Trampolin
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Trampolin"))
        {
            movimientoDireccion.y = fuerzaTrampolin;
            animacionPersonaje.SetBool("Aterrizar", true);
            Debug.Log("Personaje en el trampolín: Animación 'Saltando' activada");
        }

    }
    //Metodo de NO COLISION (Esta en el aire) con Trampolin
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trampolin"))
        {
            Debug.Log("Personaje salió del trampolín");
            animacionPersonaje.SetBool("Aterrizar", false);
        }
    }

    void CongelarPersonaje() //--C-- Método para congelar al personaje cuando el temporizador llegue a cero.
    {
        congelado = true;
        animacionPersonaje.SetBool("Aterrizar", true); //--C-- Mantener animación aterrizado.
        movimientoDireccion = Vector3.zero; //--C-- Detener el movimiento completamente.
    }

    void OnDestroy()
    {
        // Desuscribirse del evento para evitar errores al destruir el objeto
        ControlTemporizador.OnTemporizadorFinalizado -= CongelarPersonaje; //--C--
    }

}



