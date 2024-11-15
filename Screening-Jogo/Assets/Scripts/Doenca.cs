using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Doenca
{
    public string Nome { get; private set; }
    public List<string> Sintomas { get; private set; }
    public string Historico { get; private set; }
    public string MedicamentoRecomendado { get; private set; }

    public Doenca(string nome, List<string> sintomas, string historico, string medicamentoRecomendado)
    {
        Nome = nome;
        Sintomas = sintomas;
        Historico = historico;
        MedicamentoRecomendado = medicamentoRecomendado;
    }

    public string GerarDescricao()
    {
        return $"Sintomas: {string.Join(", ", Sintomas)}\nHistórico: {Historico}";
    }
}