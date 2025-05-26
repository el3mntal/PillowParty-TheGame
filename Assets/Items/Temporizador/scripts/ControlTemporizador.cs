using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTemporizador : MonoBehaviour
{
    //variables que almacenas los minutos y segundos (serialize) permite la modificacion en unity
    [SerializeField] int min, seg = 20;
    [SerializeField] Text tiempoRegresivo;

    private float cantidadTiempoTemp = 60;
    public float restanteTiempo;

    // Agrega este getter público
    public float RestanteTiempo => restanteTiempo;

    //indica si el temporizador esta en marcha
    private bool enMarchaTiempo;

    //---- Evento para avisar cuando el temporizador llega a 0----
    public delegate void TemporizadorFinalizado();
    public static event TemporizadorFinalizado OnTemporizadorFinalizado;

    private void Awake()
    {
        restanteTiempo = (min * cantidadTiempoTemp) + seg;
        enMarchaTiempo = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ejecucion del temporizador. si enMarcha es true este ira disminuyendo el tiempo del temporizador
        if (enMarchaTiempo && restanteTiempo > 0) // Condición para evitar que el tiempo sea negativo
        {
            restanteTiempo -= Time.deltaTime;
        }

        // Detener el temporizador cuando llegue a 0 segundos
        if (restanteTiempo <= 0)
        {
            restanteTiempo = 0;  // Evita que el tiempo sea negativo
            enMarchaTiempo = false; // Pausar el temporizador

            //COPILOT: Disparar el evento para avisar que el temporizador finalizó
            OnTemporizadorFinalizado?.Invoke();
        }

        // Eliminación de la variable de minutos, ahora solo se usan los segundos restantes
        int tempSeg = Mathf.FloorToInt(restanteTiempo);

        // Modificación del formato de texto para mostrar únicamente los segundos
        tiempoRegresivo.text = string.Format("{0}", tempSeg);
    }
}
