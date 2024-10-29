using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VidaNPC : MonoBehaviour
{
    public float vidaMaxima = 100f;
    private float vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima; // Inicializa a vida do NPC com o valor máximo
    }


// O medicamento correto recuperará totalmente a vida do NPC, enquanto o medicamento incorreto reduzirá a vida em 20 pontos.
    public void ReceberMedicamento(bool medicamentoCorreto)
    {
        if (medicamentoCorreto)
        {
            vidaAtual = vidaMaxima; // Recupera a vida total se o medicamento for o correto
            Debug.Log("Medicado corretamente! Vida restaurada.");
        }
        else
        {
            vidaAtual -= 20f; // Diminui a vida caso o medicamento esteja errado
            Debug.Log("Medicamento incorreto! Vida reduzida.");
            
            if (vidaAtual <= 0)
            {
                vidaAtual = 0;
                Morrer(); // Chamamos uma função de morte se a vida chegar a zero
            }
        }
    }

    void Morrer()
    {
        Debug.Log("O NPC morreu.");
        // Aqui você pode adicionar outras funcionalidades, como desativar o NPC, etc.
    }
}
