using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrutinaMonedaOro : MonoBehaviour

{
    //creacion de instancia de la corrutina (MODIFICAR NOMBRE DE CLASS Y DE INSTANCIA PARA QUE COINCIDA CUANDO CREE OTROS SCRIPS)
    public static corrutinaMonedaOro instanciaCorrutinaMoneda;

    private void Awake()
    {
        instanciaCorrutinaMoneda = this;
    }

    public void ReaparecerMoneda(GameObject moneda, Vector3 posicion, float esperaReaparecerMoneda)
    {
        StartCoroutine(ReactivarMoneda(moneda, posicion, esperaReaparecerMoneda));
    }

    private IEnumerator ReactivarMoneda(GameObject moneda, Vector3 posicion, float esperaReaparecerMoneda)
    {
        Debug.Log("Esperando para reaparecer la moneda...");
        yield return new WaitForSeconds(esperaReaparecerMoneda);

        moneda.transform.localPosition = posicion; // Restaurar la posición local
        //moneda.transform.position = posicion;
        moneda.SetActive(true);
        Debug.Log("¡Moneda reaparecida!");
    }
}
