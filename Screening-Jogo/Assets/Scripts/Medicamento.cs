using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicamento : MonoBehaviour
{
    public string tipo; // Defina um tipo único para cada medicamento, como "Painkiller", "Antibiotico", etc.

    private SoundController soundController;

    void Start()
    {
        // Encontra o SoundController no jogo
        soundController = FindObjectOfType<SoundController>();
    }

    // Método para aplicar o medicamento
    public void AplicarMedicamento(int correto)
    {
        if (correto == 1)
        {
            Debug.Log("Medicação aplicada corretamente!");
            soundController.PlaySomAcerto(); // Toca o som de acerto
        }
        else if(correto == 0)
        {
            Debug.Log("Medicação aplicada incorretamente!");
            soundController.PlaySomErro(); // Toca o som de erro
        }
        else
        {
            Debug.Log("Medicação aplicada incorretamente! Paciente morreu!");
            soundController.PlaySomMorte(); // Toca o som de morte
        }
    }
}

