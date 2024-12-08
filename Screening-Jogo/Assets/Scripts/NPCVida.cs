using System;
using UnityEngine;
using UnityEngine.UI;

public class NPCVida : MonoBehaviour
{
    public float vidaAtual = 100f;
    public float vidaMaxima = 100f;
    public Image barraVidaVerde;
    public Image barraVidaVermelha;
    private float decrementoPorSegundo;
    private Doenca doencaAtual; // Armazena a doença atribuída a este NPC

    bool estado = true;

    private void Start()
    {
        decrementoPorSegundo = vidaMaxima / 150f;
        AtualizarBarrasDeVida();
    }

    private void Update()
    {
        if (vidaAtual > 0f)
        {
            vidaAtual -= decrementoPorSegundo * Time.deltaTime;
            vidaAtual = Mathf.Clamp(vidaAtual, 0f, vidaMaxima);
            AtualizarBarrasDeVida();
        }

        if (vidaAtual <= 0) estado = false;
    }

    // Método para atribuir a doença
    public void AtribuirDoenca(Doenca doenca)
    {
        doencaAtual = doenca;
        if (doenca != null) Debug.Log("Doença atribuída ao NPC: " + (doencaAtual != null ? doencaAtual.Nome : "Nenhuma doença"));
    }

    // Método para aplicar medicamento e verificar compatibilidade com a doença atual
    public void AplicarMedicamento(GameObject remedio)
    {

        Medicamento medicamento = remedio.GetComponent<Medicamento>();
        
        if (doencaAtual == null)
        {
            Debug.LogWarning("Nenhuma doença atribuída ao paciente.");
            return;
        }

        if (estado == false) Debug.Log("O paciente já está morto!");
        
        else if (estado == true)
        {
            string nomeRemedio = remedio.name;
            Debug.Log("AplicarMedicamento chamado com o tipo de medicamento: " + nomeRemedio);

            if (nomeRemedio == doencaAtual.MedicamentoRecomendado)
            {
                if (vidaAtual >= 100)
                {
                    Debug.Log("O paciente já está com a vida cheia!");
                }
                else
                {
                    float aumento = Mathf.Min(50f, vidaMaxima - vidaAtual);
                    vidaAtual += aumento;
                    Debug.Log("Medicamento correto! Vida aumentada em " + aumento + " pontos. Vida atual: " + vidaAtual);
                    medicamento.AplicarMedicamento(1);
                }
            }
            else
            {
                if (vidaAtual <= 20)
                {
                    vidaAtual = 0;
                    estado = false;
                    Debug.Log("O paciente morreu :(");
                    medicamento.AplicarMedicamento(-1);
                }
                else
                {
                    vidaAtual -= 20f;
                    Debug.Log("Medicamento incorreto! Vida reduzida em 20 pontos. Vida atual: " + vidaAtual);
                    medicamento.AplicarMedicamento(0);
                }
            }

            vidaAtual = Mathf.Clamp(vidaAtual, 0f, vidaMaxima);
            AtualizarBarrasDeVida();
        }
    }

    private void AtualizarBarrasDeVida()
    {
        float proporcaoVida = vidaAtual / vidaMaxima;
        barraVidaVerde.fillAmount = proporcaoVida;
        barraVidaVermelha.fillAmount = 1;
    }
}
