using UnityEngine;

public class Paciente : MonoBehaviour
{
    private Doenca doencaAtual;

    public void AtribuirDoenca(Doenca doenca)
    {
        doencaAtual = doenca;
        Debug.Log("Paciente recebeu a doença: " + doenca.nome);
        ExibirSintomas();
    }

    private void ExibirSintomas()
    {
        Debug.Log("Sintomas: " + string.Join(", ", doencaAtual.sintomas));
        Debug.Log("Histórico: " + doencaAtual.historico);
        Debug.Log("Remédio correto: " + doencaAtual.remedioCorreto);
    }
}
