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
    private float restanteTiempo;
    //indica si el temporizador esta en marcha
    private bool enMarchaTiempo;

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

        // Detener el temporizador cuando llegue a 0 segundos //---C---
        if (restanteTiempo <= 0)
        {
            restanteTiempo = 0;  // Evita que el tiempo sea negativo //---C---
            enMarchaTiempo = false; // Pausar el temporizador //---C---
        }
        /*
        if (enMarchaTiempo)
        {
            restanteTiempo -= Time.deltaTime;
        }*/

        // Eliminación de la variable de minutos, ahora solo se usan los segundos restantes
        int tempSeg = Mathf.FloorToInt(restanteTiempo);

        // Modificación del formato de texto para mostrar únicamente los segundos
        tiempoRegresivo.text = string.Format("{0}", tempSeg);
    }
}

//calculo de tiempo restante al dividir minutos y segundos
//int tempMin = Mathf.FloorToInt(restanteTiempo / cantidadTiempoTemp);
//int tempSeg = Mathf.FloorToInt(restanteTiempo % cantidadTiempoTemp);
//se actualiza el tiempo y se presenta en viewport
//tiempoRegresivo.text = string.Format("{0}:{1}", tempMin, tempSeg);
