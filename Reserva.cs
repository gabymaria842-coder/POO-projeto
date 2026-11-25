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
    public EstadoReserva Estado { get; set; }

    // Associações indicadas no Diagrama de Classes:
    public UtilizadorNormal Utilizador { get; set; }
    public EspacoDesportivo Espaco { get; set; }

    // Construtor vazio necessário para a leitura do JSON
    public Reserva()
    {
    }

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
        string nomeUtilizador = Utilizador != null ? Utilizador.Nome : "Desconhecido";
        string nomeEspaco = Espaco != null ? Espaco.Nome : "Desconhecido";

        return $"[Reserva #{Id}] Espaço: {nomeEspaco} | Data: {Data:yyyy-MM-dd} | Horário: {HoraInicio} - {HoraFim} | Estado: {Estado} | Utilizador: {nomeUtilizador}";
    }
}