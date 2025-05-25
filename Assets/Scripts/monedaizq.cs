using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SonidoMoneda : MonoBehaviour
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

            // 1. Reproducir sonido
            if (sonidoRecolectado != null)
                AudioSource.PlayClipAtPoint(sonidoRecolectado, Camera.main.transform.position, volumen);

            // 2. Desactivar visualmente
            meshRenderer.enabled = false;
            colliderMoneda.enabled = false;

            // 3. Iniciar reaparición
            Invoke("ReaparecerMoneda", sonidoRecolectado.length + tiempoReaparicion);
        }
    }

    void ReaparecerMoneda()
    {
        // Reactivar moneda
        meshRenderer.enabled = true;
        colliderMoneda.enabled = true;
        recogida = false;

        // Opcional: Resetear posición si es necesario
        transform.position = posicionInicial;
    }

    void OnDisable()
    {
        // Cancelar cualquier invocación pendiente al desactivar
        CancelInvoke("ReaparecerMoneda");
    }

    void OnEnable()
    {
        // Asegurar que la moneda esté activa al reaparecer
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
