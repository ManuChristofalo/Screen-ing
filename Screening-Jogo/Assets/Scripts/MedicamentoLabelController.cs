using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicamentoLabelController : MonoBehaviour
{
    public string tipoMedicamento; // Define o tipo do medicamento
    public Canvas labelCanvas;     // Canvas associado ao label do medicamento
    public float distanciaMaxima = 4f; // Distância máxima para exibir o label

    private Camera mainCamera;
    private bool isHeld = false; // Verifica se o objeto está sendo segurado

    void Start()
    {
        mainCamera = Camera.main;

        // Garante que o canvas comece desativado
        if (labelCanvas != null)
            labelCanvas.enabled = false;
    }

    void Update()
    {
        if (isHeld) return; // Não exibe o label se o objeto estiver sendo segurado

        RaycastHit hit;

        // Lança o Raycast do centro da tela (mira)
        if (Physics.Raycast(mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)), out hit, distanciaMaxima))
        {
            if (hit.transform == transform) // Verifica se o objeto atingido é este
            {
                if (labelCanvas != null)
                    labelCanvas.enabled = true; // Ativa o canvas
            }
            else
            {
                if (labelCanvas != null)
                    labelCanvas.enabled = false; // Desativa o canvas
            }
        }
        else
        {
            if (labelCanvas != null)
                labelCanvas.enabled = false; // Desativa o canvas
        }
    }

    // Método para esconder o label manualmente
    public void HideLabel()
    {
        isHeld = true;
        if (labelCanvas != null)
            labelCanvas.enabled = false;
    }

    // Método para exibir o label manualmente
    public void ShowLabel()
    {
        isHeld = false;
    }
}
