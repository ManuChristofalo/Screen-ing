using UnityEngine;

public class MedicarNPC : MonoBehaviour
{
    public LayerMask layerNPC;
    public SegurarEPegarObjetos segurarEPegarObjetos; // Arraste o script SegurarEPegarObjetos no Inspector

    void Update()
    {
        // Verifique se o jogador pressiona a tecla "E" para tentar medicar
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Verifique se há um objeto segurado pelo script SegurarEPegarObjetos
            if (!segurarEPegarObjetos.EstaSegurandoObjeto())
            {
                Debug.LogWarning("Nenhum objeto está sendo segurado. Tente verificar o processo de pegar o objeto.");
                return;
            }

            // Raycast para verificar se o NPC está na frente
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, layerNPC))
            {
                // Verifique se o NPC tem o componente NPCVida
                NPCVida npc = hit.transform.GetComponent<NPCVida>();
                if (npc != null)
                {
                    // Verifique se o objeto segurado é um medicamento
                    Transform objetoSegurado = segurarEPegarObjetos.objetoSegurado; // Pegue o objeto diretamente do SegurarEPegarObjetos
                    if (objetoSegurado != null)
                    {
                        // Passa o GameObject do objeto segurado ao método AplicarMedicamento
                        npc.AplicarMedicamento(objetoSegurado.gameObject);
                        Debug.Log("Medicamento aplicado ao NPC");
                    }
                    else
                    {
                        Debug.Log("O objeto segurado não é um medicamento!");
                    }
                }
                else
                {
                    Debug.Log("O NPC não possui o componente NPCVida.");
                }
            }
            else
            {
                Debug.Log("Raycast não atingiu nenhum NPC.");
            }
        }
    }
}
