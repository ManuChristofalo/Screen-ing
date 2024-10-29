using UnityEngine;

public class MedicarNPC : MonoBehaviour
{
    public LayerMask layerNPC;
    public Transform pontoMao;
    private Transform objetoSegurado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, layerNPC))
            {
                Debug.Log("Raycast atingiu: " + hit.transform.name);  // Adicione isso para ver se o Raycast está funcionando
                NPCVida npc = hit.transform.GetComponent<NPCVida>();
                if (npc != null && objetoSegurado != null)
                {
                    Medicamento medicamento = objetoSegurado.GetComponent<Medicamento>();
                    if (medicamento != null)
                    {
                        npc.AplicarMedicamento(medicamento);
                        Debug.Log("Medicamento aplicado ao NPC");  // Verifica se o medicamento foi aplicado
                    }
                    else
                    {
                        Debug.Log("Nenhum medicamento na mão!");  // Verifique se você está segurando um objeto com Medicamento
                    }
                }
                else
                {
                    if (npc == null)
                    {
                        Debug.Log("NPC não possui o script NPCVida.");  // Verifique se o NPC tem o script NPCVida
                    }
                    if (objetoSegurado == null)
                    {
                        Debug.Log("Nenhum objeto está sendo segurado.");  // Verifique se o personagem está segurando um objeto
                    }
                }
            }
            else
            {
                Debug.Log("Raycast não atingiu nenhum NPC.");  // Verifique se o Raycast está acertando o NPC
            }
        }
    }


    public void SegurarObjeto(Transform objeto)
    {
        objetoSegurado = objeto;
    }
}
