using UnityEngine;

public class NPCVida : MonoBehaviour
{
    public float vidaAtual = 50f;
    public float vidaMaxima = 100f;
    public string tipoMedicamentoCorreto; // Tipo de medicamento que cura esse NPC

    public void AplicarMedicamento(Medicamento medicamento)
    {
        Debug.Log("AplicarMedicamento chamado com o tipo de medicamento: " + medicamento.tipo);
        
        if (medicamento.tipo == tipoMedicamentoCorreto)
        {
            vidaAtual = vidaMaxima;
            Debug.Log("Medicamento correto! Vida restaurada. Vida atual: " + vidaAtual);
        }
        else
        {
            vidaAtual -= 20f; // Causa dano caso o medicamento seja incorreto
            Debug.Log("Medicamento incorreto! Vida reduzida. Vida atual: " + vidaAtual);
        }
    }
}
