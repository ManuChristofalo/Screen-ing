using UnityEngine;

public class PranchetaInteraction : MonoBehaviour
{
    public GameObject canvasSintomas; // Arraste o CanvasSintomas aqui no Inspector
    private bool isLookingAtPrancheta = false; // Indica se o player está olhando para a prancheta

    void Update()
    {
        // Verifica se o player está olhando para a prancheta e aperta "E" para abrir a tela
        if (isLookingAtPrancheta && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E pressionada e olhando para a prancheta.");
            canvasSintomas.SetActive(true); // Ativa o canvas para exibir a tela
        }

        // Pressiona "Q" para fechar a tela
        if (canvasSintomas.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Tecla Q pressionada, fechando tela.");
            canvasSintomas.SetActive(false); // Desativa o canvas para fechar a tela
        }
    }

    // Detecta quando o player olha para a prancheta
    private void OnMouseOver()
    {
        isLookingAtPrancheta = true;
        Debug.Log("Olhando para a prancheta.");
    }

    // Detecta quando o player para de olhar para a prancheta
    private void OnMouseExit()
    {
        isLookingAtPrancheta = false;
        Debug.Log("Parou de olhar para a prancheta.");
    }
}
