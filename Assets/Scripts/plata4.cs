using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedaplata4 : MonoBehaviour
{
    [Header("Configuración de Sonido")]
    public AudioClip sonidoRecolectado;
    [Range(0, 1)] public float volumen = 0.7f;

    [Header("Configuración de Reaparición")]
    public float tiempoReaparicion = 5f;

    private AudioSource fuenteAudio;
    private MeshRenderer meshRenderer;
    private Collider colliderMoneda;
    private bool recogida = false;
    private Vector3 posicionInicial;

    void Awake()
    {
        fuenteAudio = gameObject.AddComponent<AudioSource>();
        fuenteAudio.playOnAwake = false;
        fuenteAudio.volume = volumen;

        meshRenderer = GetComponent<MeshRenderer>();
        colliderMoneda = GetComponent<Collider>();
        posicionInicial = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!recogida && other.CompareTag("Player"))
        {
            recogida = true;

            // Reproducir sonido
            if (sonidoRecolectado != null)
                AudioSource.PlayClipAtPoint(sonidoRecolectado, Camera.main.transform.position, volumen);

            // Desactivar visualmente
            meshRenderer.enabled = false;
            colliderMoneda.enabled = false;

            // Iniciar reaparición
            Invoke("ReaparecerMoneda", sonidoRecolectado.length + tiempoReaparicion);
        }
    }

    void ReaparecerMoneda()
    {
        meshRenderer.enabled = true;
        colliderMoneda.enabled = true;
        recogida = false;
        transform.position = posicionInicial;
    }

    void OnDisable()
    {
        CancelInvoke("ReaparecerMoneda");
    }

    void OnEnable()
    {
        if (recogida)
        {
            meshRenderer.enabled = false;
            colliderMoneda.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
            colliderMoneda.enabled = true;
        }
    }
}
