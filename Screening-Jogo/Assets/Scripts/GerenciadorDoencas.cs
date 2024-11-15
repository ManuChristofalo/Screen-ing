using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GerenciadorDoencas : MonoBehaviour
{
    private List<Doenca> doencas;
    public TextMeshProUGUI textoPrancheta; // arraste o TextMeshPro do Canvas para esta referência no Inspector

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
        Paciente[] pacientes = FindObjectsOfType<Paciente>();
        
        foreach (Paciente paciente in pacientes)
        {
            Doenca doencaRandom = doencas[Random.Range(0, doencas.Count)];
            paciente.AtribuirDoenca(doencaRandom);

            PranchetaInteraction prancheta = paciente.GetComponentInChildren<PranchetaInteraction>();
            if (prancheta != null)
            {
                prancheta.AtribuirDoenca(doencaRandom);
            }
            else
            {
                Debug.LogWarning($"Prancheta não encontrada para o paciente: {paciente.name}");
            }
        }
    }
}
