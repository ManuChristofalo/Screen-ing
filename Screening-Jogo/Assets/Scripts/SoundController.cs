using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip somAmbiente; // Música ambiente
    public AudioClip somAcerto;   // Som para medicação correta
    public AudioClip somErro;     // Som para medicação incorreta
    public AudioClip somMorte;
    private AudioSource audioSource;

    void Start()
    {
        // Obtém o AudioSource no mesmo objeto
        audioSource = GetComponent<AudioSource>();

        // Configura o som ambiente para tocar no início do jogo
        if (somAmbiente != null)
        {
            audioSource.clip = somAmbiente;
            audioSource.loop = true; // Repete o som ambiente
            audioSource.Play();      // Começa a tocar o som ambiente
        }
    }

    // Método para tocar o som de acerto
    public void PlaySomAcerto()
    {
        if (somAcerto != null)
        {
            audioSource.PlayOneShot(somAcerto); // Toca o som de acerto uma vez
        }
    }

    // Método para tocar o som de erro
    public void PlaySomErro()
    {
        if (somErro != null)
        {
            audioSource.PlayOneShot(somErro); // Toca o som de erro uma vez
        }
    }

    public void PlaySomMorte()
    {
        if (somMorte != null)
        {
            audioSource.PlayOneShot(somMorte); // Toca o som de erro uma vez
        }
    }
}
