using UnityEngine;
using System.Collections.Generic;

public class GerenciadorDoencas : MonoBehaviour
{
    private List<Doenca> doencas;

    void Start()
    {
        doencas = new List<Doenca>
        {
            new Doenca("Ressaca", new List<string> { "dor de cabeça", "fotofobia", "sede", "tontura", "desorientação", "ânsia" }, "Participou de uma festa ontem à noite", "SoroCapsula"),
            new Doenca("Picada de Aranha", new List<string> { "dor intensa", "inchaço", "náusea", "vômito", "febre", "suor excessivo" }, "Estava arrumando caixas na garagem", "AntiHistaminico"),
            new Doenca("Gripe", new List<string> { "febre", "calafrios", "dores musculares", "tosse", "congestão", "coriza", "dor de cabeça", "fadiga" }, "Nada relevante", "Benegrip"),
            new Doenca("Queimadura Grave", new List<string> { "bolhas", "pele avermelhada", "manchas", "dor", "inchaço", "desprendimento de pele" }, "Chefe de cozinha", "Morfina"),
            new Doenca("Virose", new List<string> { "diarreia", "febre", "vômito", "enjoo", "dor na barriga" }, "Foi para a praia ontem", "Repoflor")
        };

        RandomizarDoencasParaPacientes();
    }

    private void RandomizarDoencasParaPacientes()
    {
        // Encontra todos os NPCs com o script Paciente
        Paciente[] pacientes = FindObjectsOfType<Paciente>();
        
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.layer == LayerMask.NameToLayer("NPC"))
            {
                NPCVida npc = obj.GetComponent<NPCVida>();
                if (npc != null)
                {
                    // Escolhe uma doença aleatória para cada paciente
                    Doenca doencaRandom = doencas[Random.Range(0, doencas.Count)];
                    npc.AtribuirDoenca(doencaRandom);
                }
            }
        }
    }
}
