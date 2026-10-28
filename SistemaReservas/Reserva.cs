using System;

public enum EstadoReserva
{
    Pendente,
    Confirmada,
    Cancelada,
    Concluida
}

public class Reserva
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public EstadoReserva Estado { get; private set; }
    public string UtilizadorId { get; set; }

    public Reserva(int id, DateTime data, TimeSpan horaInicio, TimeSpan horaFim, string utilizadorId)
    {
        Id = id;
        Data = data;
        HoraInicio = horaInicio;
        HoraFim = horaFim;
        Estado = EstadoReserva.Pendente; // Toda a reserva começa como PENDENTE
        UtilizadorId = utilizadorId;
    }

    // Método para alterar o estado (ex: de Pendente para Confirmada ou Cancelada)
    public void AtualizarEstado(EstadoReserva novoEstado)
    {
        Estado = novoEstado;
    }

    // Método para alterar os dados de horário da reserva
    public void AtualizarHorario(DateTime novaData, TimeSpan novaHoraInicio, TimeSpan novaHoraFim)
    {
        Data = novaData;
        HoraInicio = novaHoraInicio;
        HoraFim = novaHoraFim;
    }

    public override string ToString()
    {
        return $"[Reserva #{Id}] Data: {Data:yyyy-MM-dd} | Horário: {HoraInicio} - {HoraFim} | Estado: {Estado} | Utilizador: {UtilizadorId}";
    }
}