using UnityEngine;

public class MedicarNPC : MonoBehaviour
{
    public LayerMask layerNPC;       // Define a Layer para identificar o NPC
    public bool medicamentoCorreto;  // Define se o medicamento é correto ou não
    public float distanciaMaxima = 2.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            // Lança o Raycast da posição da câmera
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaMaxima, layerNPC))
            {
                // Verifica se o objeto atingido tem o componente VidaNPC
                VidaNPC vidaNPC = hit.transform.GetComponent<VidaNPC>();

                if (vidaNPC != null)
                {
                    vidaNPC.ReceberMedicamento(medicamentoCorreto);
                }
            }
        }
    }
}
