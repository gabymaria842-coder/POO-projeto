using System;
using System.Collections.Generic;
using System.Linq;
using GestaoEspacosDesportivos;

public class GestaoReservas
{
    private List<Reserva> _reservas = new List<Reserva>();
    private int _proximoId = 1;
    private GestorSistema _gestor;

    public GestaoReservas(GestorSistema gestor = null)
    {
        _gestor = gestor;

        if (_gestor != null && _gestor.listaReservas.Count > 0)
        {
            _reservas = _gestor.listaReservas;
            _proximoId = _reservas.Max(r => r.Id) + 1;
        }
    }

    // Criar Reserva (recebe o UtilizadorNormal e o EspacoDesportivo reais)
    public Reserva CriarReserva(DateTime data, TimeSpan horaInicio, TimeSpan horaFim, UtilizadorNormal utilizador, EspacoDesportivo espaco)
    {
        if (horaInicio >= horaFim)
        {
            throw new ArgumentException("A hora de início deve ser anterior à hora de fim.");
        }

        if (utilizador == null || espaco == null)
        {
            throw new ArgumentException("Utilizador e espaço desportivo são obrigatórios.");
        }

        Reserva novaReserva = new Reserva(_proximoId++, data, horaInicio, horaFim, utilizador, espaco);
        _reservas.Add(novaReserva);

        if (_gestor != null)
        {
            _gestor.listaReservas = _reservas;
            _gestor.GuardarDados();
        }

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
        if (novaHoraInicio >= novaHoraFim)
        {
            return false;
        }

        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        // Só permite alterar se ainda estiver Pendente ou Confirmada
        if (reserva.Estado == EstadoReserva.Cancelada || reserva.Estado == EstadoReserva.Concluida)
        {
            return false;
        }

        reserva.AtualizarHorario(novaData, novaHoraInicio, novaHoraFim);

        if (_gestor != null)
        {
            _gestor.GuardarDados();
        }

        return true;
    }

    // Alterar Estado (Aprovação por Administrador)
    public bool AlterarEstadoReserva(int id, EstadoReserva novoEstado)
    {
        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        reserva.AtualizarEstado(novoEstado);

        if (_gestor != null)
        {
            _gestor.GuardarDados();
        }

        return true;
    }

    // Cancelar Reserva
    public bool CancelarReserva(int id)
    {
        Reserva reserva = ConsultarPorId(id);
        if (reserva == null) return false;

        reserva.AtualizarEstado(EstadoReserva.Cancelada);

        if (_gestor != null)
        {
            _gestor.GuardarDados();
        }

        return true;
    }
}