using System;
using System.Collections.Generic;

/// <summary>
/// Campo, court ou pavilhão.
/// Relação de COMPOSIÇÃO com Equipamento: os equipamentos são criados dentro do
/// espaço (como o Emprestimo cria o Membro e o Item) e só existem através dele.
/// </summary>
class EspacoDesportivo
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = "";
    public string Tipo { get; private set; } = "";        // ex.: "Campo de futebol", "Court de ténis", "Pavilhão"
    public string Localizacao { get; private set; } = "";
    public int Capacidade { get; private set; }
    public string Estado { get; private set; } = "Disponível"; // "Disponível", "Ocupado" ou "Em manutenção"

    private List<Equipamento> equipamentos; //add equipamento

    public EspacoDesportivo(int id, string nome, string tipo, string localizacao, int capacidade)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Localizacao = localizacao;
        Capacidade = capacidade;
        Estado = "Disponível";

        // Composição: a lista nasce e vive dentro do espaço
        equipamentos = new List<Equipamento>();
    }

    public void SetEstado(string estado)
    {
        if (estado == "Disponível" || estado == "Ocupado" || estado == "Em manutenção")
        {
            Estado = estado;
        }
        else
        {
            Console.WriteLine("Estado inválido. Use: Disponível, Ocupado ou Em manutenção.");
        }
    }

    public bool VerificarDisponibilidade()
    {
        return Estado == "Disponível";
    }

    // O equipamento é criado dentro do espaço (composição)
    public void AdicionarEquipamento(int id, string nome, int quantidade, string estadoConservacao)
    {
        if (equipamentos.Exists(e => e.Id == id))
        {
            Console.WriteLine($"Já existe um equipamento com o ID {id}.");
            return;
        }
        equipamentos.Add(new Equipamento(id, nome, quantidade, estadoConservacao));
    }

    public bool RemoverEquipamento(int id)
    {
        return equipamentos.RemoveAll(e => e.Id == id) > 0;
    }

    public Equipamento? ObterEquipamento(int id)
    {
        return equipamentos.Find(e => e.Id == id);
    }

    public int GetNumeroEquipamentos()
    {
        return equipamentos.Count;
    }

    public void ListarEquipamentos()
    {
        if (equipamentos.Count == 0)
        {
            Console.WriteLine("  (sem equipamentos)");
            return;
        }
        foreach (var e in equipamentos)
        {
            Console.WriteLine("  " + e);
        }
    }

    public override string ToString()
    {
        return $"[{Id}] {Nome} ({Tipo}) - {Localizacao} | Capacidade: {Capacidade} | Estado: {Estado}";
    }
}
