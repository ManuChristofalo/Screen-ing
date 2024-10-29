using UnityEngine;

public class MedicarNPC : MonoBehaviour
{
    public LayerMask layerNPC;
    public Transform pontoMao;
    public Transform objetoSegurado;
    public SegurarEPegarObjetos segurarEPegarObjetos; // arraste o script SegurarEPegarObjetos no Inspector


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objetoSegurado == null)
            {
                Debug.LogWarning("Nenhum objeto está sendo segurado. Tente verificar o processo de pegar o objeto.");
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, layerNPC))
            {
                NPCVida npc = hit.transform.GetComponent<NPCVida>();
                if (npc != null)
                {
                    Medicamento medicamento = objetoSegurado.GetComponent<Medicamento>();
                    if (medicamento != null)
                    {
                        npc.AplicarMedicamento(medicamento);
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



    public void SegurarObjeto(Transform objeto)
    {
        objetoSegurado = objeto;
    }
}
