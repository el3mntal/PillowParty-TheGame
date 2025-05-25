using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaltoSonido : MonoBehaviour
{
    public AudioClip sonidoSalto;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampolin")) // Verifica si toc� el trampol�n
        {
            audioSource.PlayOneShot(sonidoSalto);
        }
    }
}
