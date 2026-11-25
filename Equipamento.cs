using System;

/// <summary>
/// Material associado a um espaço desportivo (bolas, redes, coletes, etc.).
/// </summary>
public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public int Quantidade { get; set; }
    public string EstadoConservacao { get; set; } = ""; // "Novo", "Bom", "Usado" ou "Danificado"

    // Construtor vazio necessário para a leitura do JSON
    public Equipamento()
    {
    }

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