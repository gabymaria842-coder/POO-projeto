using System;

/// <summary>
/// Material associado a um espaço desportivo (bolas, redes, coletes, etc.).
/// </summary>
class Equipamento
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = "";
    public int Quantidade { get; private set; }
    public string EstadoConservacao { get; private set; } = ""; // "Novo", "Bom", "Usado" ou "Danificado"

    public Equipamento(int id, string nome, int quantidade, string estadoConservacao)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        EstadoConservacao = estadoConservacao;
    }

    public void SetQuantidade(int quantidade)
    {
        if (quantidade < 0)
        {
            Console.WriteLine("A quantidade não pode ser negativa.");
            return;
        }
        Quantidade = quantidade;
    }

    public void SetEstadoConservacao(string estado)
    {
        EstadoConservacao = estado;
    }

    public override string ToString()
    {
        return $"[{Id}] {Nome} | Quantidade: {Quantidade} | Estado: {EstadoConservacao}";
    }
}
