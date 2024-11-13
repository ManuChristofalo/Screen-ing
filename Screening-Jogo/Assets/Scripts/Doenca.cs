using System.Collections.Generic;

public class Doenca
{
    public string nome;
    public List<string> sintomas;
    public string historico;
    public string remedioCorreto;

    public Doenca(string nome, List<string> sintomas, string historico, string remedioCorreto)
    {
        this.nome = nome;
        this.sintomas = sintomas;
        this.historico = historico;
        this.remedioCorreto = remedioCorreto;
    }
}
