using UnityEngine;
using UnityEngine.UI;

public class NPCVida : MonoBehaviour
{
    public float vidaAtual = 100f;
    public float vidaMaxima = 100f;
    public string tipoMedicamentoCorreto; // Tipo de medicamento que cura esse NPC
    public Image barraVidaVerde; // Referência à imagem "VidaVerde"
    public Image barraVidaVermelha; // Referência à imagem "VidaVermelha"
    private float decrementoPorSegundo; // Quantidade de vida a ser decrementada por segundo

    private void Start()
    {
        decrementoPorSegundo = vidaMaxima / 150f; // Calcula o decremento para 150s até vida 0
        AtualizarBarrasDeVida(); // Atualiza o tamanho inicial das barras
    }

    private void Update()
    {
        // Diminui a vida ao longo do tempo enquanto a vida é maior que 0
        if (vidaAtual > 0f)
        {
            vidaAtual -= decrementoPorSegundo * Time.deltaTime;
            vidaAtual = Mathf.Clamp(vidaAtual, 0f, vidaMaxima); // Limita a vida a no mínimo 0
            AtualizarBarrasDeVida();
        }
    }

    public void AplicarMedicamento(Medicamento medicamento)
    {
        Debug.Log("AplicarMedicamento chamado com o tipo de medicamento: " + medicamento.tipo);

        if (medicamento.tipo == tipoMedicamentoCorreto){
            if(vidaAtual == 0) Debug.Log("O paciente já está morto!");
            if(vidaAtual == 100) Debug.Log("Medicamento correto!");
            else if(vidaAtual > 80){
                float dif = 100 - vidaAtual;
                vidaAtual = 100;
                Debug.Log("Medicamento correto! Vida aumentada em " + dif + " pontos. Vida atual: " + vidaAtual);
            }
            else{ 
                vidaAtual += 20f; // Aumenta 20 pontos de vida
                Debug.Log("Medicamento correto! Vida aumentada em 50 pontos. Vida atual: " + vidaAtual);
            }
        }
        else{
            if(vidaAtual == 0) Debug.Log("O paciente já está morto!");
            else if(vidaAtual <= 10){
                vidaAtual = 0;
                 Debug.Log("O paciente morreu :(");
            }
            else{
                vidaAtual -= 10f; // Reduz 10 pontos de vida se o medicamento for incorreto
                Debug.Log("Medicamento incorreto! Vida reduzida em 20 pontos. Vida atual: " + vidaAtual);
            }
        }

        // Garante que a vida não ultrapasse os limites de 0 e 100
        //vidaAtual = Mathf.Clamp(vidaAtual, 0f, vidaMaxima);
        AtualizarBarrasDeVida();
    }

    private void AtualizarBarrasDeVida()
    {
        float proporcaoVida = vidaAtual / vidaMaxima;

        // Atualiza a barra "VidaVerde" com a proporção de vida atual
        barraVidaVerde.fillAmount = proporcaoVida;

        // Atualiza a barra "VidaVermelha" com a proporção de vida consumida
        //barraVidaVermelha.fillAmount = 1 - proporcaoVida;
    }
}
