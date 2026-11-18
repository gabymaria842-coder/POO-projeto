using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GestaoEspacosDesportivos
{
    public static class PersistenciaJson
    {
        private const string FicheiroUtilizadores = "utilizadores.json";
        private const string FicheiroEspacos = "espacos.json";
        private const string FicheiroReservas = "reservas.json";

        // Guardar dados
        public static void Guardar(List<Utilizador> utilizadores, List<EspacoDesportivo> espacos, List<Reserva> reservas)
        {
            try
            {
                File.WriteAllText(FicheiroUtilizadores, JsonSerializer.Serialize(utilizadores));
                File.WriteAllText(FicheiroEspacos, JsonSerializer.Serialize(espacos));
                File.WriteAllText(FicheiroReservas, JsonSerializer.Serialize(reservas));
                Console.WriteLine("Dados guardados com sucesso no JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao guardar os dados: " + ex.Message);
            }
        }

        // Carregar Utilizadores
        public static List<Utilizador> CarregarUtilizadores()
        {
            if (File.Exists(FicheiroUtilizadores))
            {
                string json = File.ReadAllText(FicheiroUtilizadores);
                return JsonSerializer.Deserialize<List<Utilizador>>(json) ?? new List<Utilizador>();
            }
            return new List<Utilizador>();
        }

        // Carregar Espaços
        public static List<EspacoDesportivo> CarregarEspacos()
        {
            if (File.Exists(FicheiroEspacos))
            {
                string json = File.ReadAllText(FicheiroEspacos);
                return JsonSerializer.Deserialize<List<EspacoDesportivo>>(json) ?? new List<EspacoDesportivo>();
            }
            return new List<EspacoDesportivo>();
        }

        // Carregar Reservas
        public static List<Reserva> CarregarReservas()
        {
            if (File.Exists(FicheiroReservas))
            {
                string json = File.ReadAllText(FicheiroReservas);
                return JsonSerializer.Deserialize<List<Reserva>>(json) ?? new List<Reserva>();
            }
            return new List<Reserva>();
        }
    }
}
