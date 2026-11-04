using System;

/// <summary>
/// Teste do Elemento 2. Chama DemoElemento2.Executar() a partir do Main do projeto
/// (ou apaga este ficheiro quando o GestorSistema estiver integrado).
/// </summary>
static class DemoElemento2
{
    public static void Executar()
    {
        Console.WriteLine("=== Módulo de Espaços Desportivos ===");

        // 1. Criar o espaço
        EspacoDesportivo pavilhao = new EspacoDesportivo(1, "Pavilhão Municipal", "Pavilhão", "Coimbra", 200);
        Console.WriteLine(pavilhao);

        // 2. Adicionar equipamentos (composição)
        pavilhao.AdicionarEquipamento(1, "Bola de basquetebol", 10, "Bom");
        pavilhao.AdicionarEquipamento(2, "Rede de voleibol", 2, "Novo");
        pavilhao.AdicionarEquipamento(3, "Coletes", 20, "Usado");

        Console.WriteLine("\nEquipamentos:");
        pavilhao.ListarEquipamentos();

        // 3. Verificar disponibilidade
        Console.WriteLine($"\nDisponível? {pavilhao.VerificarDisponibilidade()}");
        pavilhao.SetEstado("Em manutenção");
        Console.WriteLine($"Após manutenção, disponível? {pavilhao.VerificarDisponibilidade()}");

        // 4. Remover equipamento
        pavilhao.RemoverEquipamento(3);
        Console.WriteLine($"\nApós remover os coletes, existem {pavilhao.GetNumeroEquipamentos()} equipamentos:");
        pavilhao.ListarEquipamentos();

        // 5. ID repetido
        Console.WriteLine();
        pavilhao.AdicionarEquipamento(1, "Outra bola", 1, "Novo");
    }
}
