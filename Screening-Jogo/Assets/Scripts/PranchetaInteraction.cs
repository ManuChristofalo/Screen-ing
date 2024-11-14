using UnityEngine;
using TMPro;

public class PranchetaInteraction : MonoBehaviour
{
    public GameObject canvasSintomas; // Arraste o CanvasSintomas aqui no Inspector
    private bool isLookingAtPrancheta = false; // Indica se o player está olhando para a prancheta
    public float maxRaycastDistance = 5f; // Distância máxima para detectar a prancheta
    public TextMeshProUGUI sintomasText;
    public TextMeshProUGUI historicoText;

    void Start()
    {
        // Esconde o canvas de sintomas no início
        canvasSintomas.SetActive(false);
    }

    void Update()
    {
        // Envia um Raycast a partir do centro da tela para detectar a prancheta
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Verifica se o Raycast atinge a prancheta dentro da distância máxima
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            if (hit.transform == transform) // Checa se o objeto atingido é a prancheta
            {
                if (!isLookingAtPrancheta)
                {
                    Debug.Log("Olhando para a prancheta.");
                }
                isLookingAtPrancheta = true;
            }
            else
            {
                if (isLookingAtPrancheta)
                {
                    Debug.Log("Parou de olhar para a prancheta.");
                }
                isLookingAtPrancheta = false;
            }
        }
        else
        {
            if (isLookingAtPrancheta)
            {
                Debug.Log("Parou de olhar para a prancheta.");
            }
            isLookingAtPrancheta = false;
        }

        // Verifica se o player está olhando para a prancheta e aperta "E" para abrir a tela
        if (isLookingAtPrancheta && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E pressionada e olhando para a prancheta.");
            canvasSintomas.SetActive(true); // Ativa o canvas para exibir a tela
            MostrarInformacoesPaciente("Dor de cabeça, fotofobia, sede, tontura, desorientação, ânsia.", 
                                       "Paciente relata ter participado de uma festa ontem à noite");
        }

        // Pressiona "Q" para fechar a tela
        if (canvasSintomas.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Tecla Q pressionada, fechando tela.");
            canvasSintomas.SetActive(false); // Desativa o canvas para fechar a tela
        }
    }

    void MostrarInformacoesPaciente(string sintomas, string historico)
    {
        // Exibir informações do paciente
        sintomasText.text = sintomas;
        historicoText.text = historico;    
        
        canvasSintomas.SetActive(true); // Ativa a tela de informações
    }
}
