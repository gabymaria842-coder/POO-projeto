using System;
using System.Collections.Generic;

/// <summary>
/// Campo, court ou pavilhão.
/// Relação de COMPOSIÇÃO com Equipamento: os equipamentos são criados dentro do
/// espaço e só existem através dele.
/// </summary>
public class EspacoDesportivo
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Tipo { get; set; } = "";        // ex.: "Campo de futebol", "Court de ténis", "Pavilhão"
    public string Localizacao { get; set; } = "";
    public int Capacidade { get; set; }
    public string Estado { get; set; } = "Disponível"; // "Disponível", "Ocupado" ou "Em manutenção"

    // Propriedade pública para o JSON guardar e carregar os equipamentos
    public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    // Construtor vazio necessário para a leitura do JSON
    public EspacoDesportivo()
    {
    }

    public EspacoDesportivo(int id, string nome, string tipo, string localizacao, int capacidade)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Localizacao = localizacao;
        Capacidade = capacidade;
        Estado = "Disponível";
        Equipamentos = new List<Equipamento>();
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
        if (Equipamentos.Exists(e => e.Id == id))
        {
            Console.WriteLine($"Já existe um equipamento com o ID {id}.");
            return;
        }
        Equipamentos.Add(new Equipamento(id, nome, quantidade, estadoConservacao));
    }

    public bool RemoverEquipamento(int id)
    {
        return Equipamentos.RemoveAll(e => e.Id == id) > 0;
    }

    public Equipamento ObterEquipamento(int id)
    {
        return Equipamentos.Find(e => e.Id == id);
    }

    public int GetNumeroEquipamentos()
    {
        return Equipamentos.Count;
    }

    public void ListarEquipamentos()
    {
        if (Equipamentos.Count == 0)
        {
            Console.WriteLine("  (sem equipamentos)");
            return;
        }
        foreach (Equipamento e in Equipamentos)
        {
            Console.WriteLine("  " + e);
        }
    }

    public override string ToString()
    {
        return $"[{Id}] {Nome} ({Tipo}) - {Localizacao} | Capacidade: {Capacidade} | Estado: {Estado}";
    }
}