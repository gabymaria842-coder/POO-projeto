using System;
using System.Collections.Generic;
using System.Linq;

public class GestaoReservas
{
    private List<Reserva> _reservas = new List<Reserva>();
    private int _proximoId = 1;

    // Criar Reserva
    public Reserva CriarReserva(DateTime data, TimeSpan horaInicio, TimeSpan horaFim, string utilizadorId)
    {
        // Validação simples de horários
        if (horaInicio >= horaFim)
        {
            throw new ArgumentException("A hora de início deve ser anterior à hora de fim.");
        }

        Reserva novaReserva = new Reserva(_proximoId++, data, horaInicio, horaFim, utilizadorId);
        _reservas.Add(novaReserva);
        return novaReserva;
    }

    // Consultar todas as reservas
    public List<Reserva> ConsultarTodas()
    {
        return _reservas;
    }

    // Consultar por ID
    public Reserva ConsultarPorId(int id)
    {
        return _reservas.FirstOrDefault(r => r.Id == id);
    }

    // Alterar Reserva (Horários)
    public bool AlterarReserva(int id, DateTime novaData, TimeSpan novaHoraInicio, TimeSpan novaHoraFim)
    {
        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        // Só permite alterar se ainda estiver Pendente ou Confirmada
        if (reserva.Estado == EstadoReserva.Cancelada || reserva.Estado == EstadoReserva.Concluida)
        {
            return false; 
        }

        reserva.AtualizarHorario(novaData, novaHoraInicio, novaHoraFim);
        return true;
    }

    // Alterar Estado (Aprovação por Administrador)
    public bool AlterarEstadoReserva(int id, EstadoReserva novoEstado)
    {
        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        reserva.AtualizarEstado(novoEstado);
        return true;
    }

    // Cancelar Reserva
    public bool CancelarReserva(int id)
    {
        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        reserva.AtualizarEstado(EstadoReserva.Cancelada);
        return true;
    }
}