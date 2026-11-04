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
    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public TimeSpan HoraInicio { get; private set; }
    public TimeSpan HoraFim { get; private set; }
    public EstadoReserva Estado { get; private set; }
    
    // Associações indicadas no Diagrama de Classes:
    public UtilizadorNormal Utilizador { get; private set; }
    public EspacoDesportivo Espaco { get; private set; }

    // Construtor atualizado que recebe o UtilizadorNormal e o EspacoDesportivo
    public Reserva(int id, DateTime data, TimeSpan horaInicio, TimeSpan horaFim, UtilizadorNormal utilizador, EspacoDesportivo espaco)
    {
        Id = id;
        Data = data;
        HoraInicio = horaInicio;
        HoraFim = horaFim;
        Estado = EstadoReserva.Pendente; // Toda a reserva começa como PENDENTE
        Utilizador = utilizador;
        Espaco = espaco;
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
        string nomeUtilizador = Utilizador != null ? Utilizador.nome : "Desconhecido";
        string nomeEspaco = Espaco != null ? Espaco.Nome : "Desconhecido";

        return $"[Reserva #{Id}] Espaço: {nomeEspaco} | Data: {Data:yyyy-MM-dd} | Horário: {HoraInicio} - {HoraFim} | Estado: {Estado} | Utilizador: {nomeUtilizador}";
    }
}