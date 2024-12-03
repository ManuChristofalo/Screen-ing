using UnityEngine;
using TMPro;

public class PranchetaInteraction : MonoBehaviour
{
    public GameObject canvasSintomas; // Arraste o CanvasSintomas no Inspector
    public TextMeshProUGUI sintomasText; // Campo para o texto de sintomas
    public TextMeshProUGUI historicoText; // Campo para o texto de histórico
    public float maxRaycastDistance = 5f; // Distância máxima do Raycast

    private bool isLookingAtPrancheta = false; // Indica se o jogador está olhando para a prancheta
    private Doenca doencaAtual; // Doença atribuída ao paciente

    void Start()
    {
        // Esconde o Canvas ao iniciar o jogo
        canvasSintomas.SetActive(false);
    }

    public void AtribuirDoenca(Doenca doenca)
    {
        doencaAtual = doenca;
        if (doenca != null)
        {
            Debug.Log($"Doença '{doenca.Nome}' atribuída à prancheta.");
        }
        else
        {
            Debug.LogWarning("Tentativa de atribuir uma doença nula à prancheta.");
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRaycastDistance) && hit.transform == transform)
        {
            isLookingAtPrancheta = true;
            Debug.Log("Olhando para a prancheta.");
        }
        else
        {
            isLookingAtPrancheta = false;
        }

        if (isLookingAtPrancheta && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Olhando para a prancheta e pressionando 'E'. Tentando mostrar informações do paciente.");
            MostrarInformacoesPaciente();
        }

        if (canvasSintomas.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Canvas está ativo e pressionando 'Q'. Fechando o canvas.");
            FecharCanvas();
        }
    }

    void MostrarInformacoesPaciente()
    {
        if (doencaAtual == null)
        {
            Debug.LogWarning("doencaAtual está nulo. Certifique-se de que uma doença foi atribuída a esta prancheta.");
            return;
        }

        // Atualiza os textos no Canvas
        if (sintomasText != null && historicoText != null)
        {
            sintomasText.text = $"Sintomas: {string.Join(", ", doencaAtual.Sintomas)}";
            historicoText.text = $"Histórico: {doencaAtual.Historico}";
        }
        else
        {
            Debug.LogError("Campos de texto não atribuídos no Inspector.");
        }

        // Ativa o Canvas
        if (canvasSintomas != null)
        {
            canvasSintomas.SetActive(true);
        }
        else
        {
            Debug.LogError("CanvasSintomas não foi atribuído no Inspector.");
        }
    }

    void FecharCanvas()
    {
        // Fecha o Canvas
        canvasSintomas.SetActive(false);
    }
}
