using System;

class Program
{
    static void Main(string[] args)
    {
        GestaoReservas sistema = new GestaoReservas();

        // 1. Criar uma reserva
        Reserva r1 = sistema.CriarReserva(DateTime.Today.AddDays(1), new TimeSpan(14, 0, 0), new TimeSpan(16, 0, 0), "utilizador123");
        Console.WriteLine("Reserva criada com sucesso:");
        Console.WriteLine(r1);

        // 2. Consultar reservas
        Console.WriteLine("\n--- Lista de Reservas ---");
        foreach (var r in sistema.ConsultarTodas())
        {
            Console.WriteLine(r);
        }

        // 3. Administrador confirma a reserva (Transição de Estado)
        sistema.AlterarEstadoReserva(r1.Id, EstadoReserva.Confirmada);
        Console.WriteLine($"\nApós aprovação do Admin: {sistema.ConsultarPorId(r1.Id).Estado}");

        // 4. Cancelar reserva
        sistema.CancelarReserva(r1.Id);
        Console.WriteLine($"Após cancelamento: {sistema.ConsultarPorId(r1.Id).Estado}");
    }
}