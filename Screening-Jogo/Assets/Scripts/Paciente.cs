using UnityEngine;

public class Paciente : MonoBehaviour
{
    private Doenca doencaAtual;

    public void AtribuirDoenca(Doenca doenca)
    {
        doencaAtual = doenca;
        Debug.Log("Paciente recebeu a doença: " + doenca.Nome);
        ExibirSintomas();
    }

    private void ExibirSintomas()
    {
        Debug.Log("Sintomas: " + string.Join(", ", doencaAtual.Sintomas));
        Debug.Log("Histórico: " + doencaAtual.Historico);
        Debug.Log("Remédio correto: " + doencaAtual.MedicamentoRecomendado);
    }
}
