using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoNube : MonoBehaviour
{
    public float velocidadNube = 5f; // Velocidad ajustable desde el Inspector o el código.

    void Update()
    {
        // Mueve la nube en el eje Z.
        transform.Translate(Vector3.forward * velocidadNube * Time.deltaTime);

        // Reinicia la posición si alcanza el límite.
        if (transform.position.z > 300)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -300);
        }
    }
}
