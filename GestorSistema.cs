using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GestaoEspacosDesportivos //foram feitas ligeiras alterações para ficar de acordo com o diagrama de classes 
{
    public class GestorSistema
    {
        // Listas com os nomes exatos do diagrama
        public List<Utilizador> listaUtilizadores { get; set; } = new List<Utilizador>();
        public List<EspacoDesportivo> listaEspacos { get; set; } = new List<EspacoDesportivo>();
        public List<Reserva> listaReservas { get; set; } = new List<Reserva>();

        private const string FicheiroUtilizadores = "utilizadores.json";
        private const string FicheiroEspacos = "espacos.json";
        private const string FicheiroReservas = "reservas.json";

        // ---------- Adicionar (Com retorno bool como no diagrama) ----------

        public bool AdicionarUtilizador(Utilizador utilizador)
        {
            listaUtilizadores.Add(utilizador);
            Console.WriteLine("Utilizador adicionado com sucesso.");
            return true;
        }

        public bool AdicionarEspaco(EspacoDesportivo espaco)
        {
            listaEspacos.Add(espaco);
            Console.WriteLine("Espaço desportivo adicionado com sucesso.");
            return true;
        }

        public bool AdicionarReserva(Reserva reserva)
        {
            listaReservas.Add(reserva);
            Console.WriteLine("Reserva adicionada com sucesso.");
            return true;
        }

        // ---------- Remover (Em falta no teu código, adicionados agora) ----------

        public bool RemoverUtilizador(string id)
        {
            Utilizador u = listaUtilizadores.Find(x => x.id == id);
            if (u != null)
            {
                listaUtilizadores.Remove(u);
                Console.WriteLine("Utilizador removido com sucesso.");
                return true;
            }
            return false;
        }

        public bool RemoverEspaco(string id)
        {
            EspacoDesportivo e = listaEspacos.Find(x => x.id == id);
            if (e != null)
            {
                listaEspacos.Remove(e);
                Console.WriteLine("Espaço removido com sucesso.");
                return true;
            }
            return false;
        }

        // ---------- Persistência em ficheiros (Mantém-se igual) ----------

        public void GuardarDados()
        {
            try
            {
                File.WriteAllText(FicheiroUtilizadores, JsonSerializer.Serialize(listaUtilizadores));
                File.WriteAllText(FicheiroEspacos, JsonSerializer.Serialize(listaEspacos));
                File.WriteAllText(FicheiroReservas, JsonSerializer.Serialize(listaReservas));
                Console.WriteLine("Dados guardados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao guardar os dados: " + ex.Message);
            }
        }

        public void CarregarDados()
        {
            try
            {
                if (File.Exists(FicheiroUtilizadores))
                {
                    string json = File.ReadAllText(FicheiroUtilizadores);
                    listaUtilizadores = JsonSerializer.Deserialize<List<Utilizador>>(json) ?? new List<Utilizador>();
                }

                if (File.Exists(FicheiroEspacos))
                {
                    string json = File.ReadAllText(FicheiroEspacos);
                    listaEspacos = JsonSerializer.Deserialize<List<EspacoDesportivo>>(json) ?? new List<EspacoDesportivo>();
                }

                if (File.Exists(FicheiroReservas))
                {
                    string json = File.ReadAllText(FicheiroReservas);
                    listaReservas = JsonSerializer.Deserialize<List<Reserva>>(json) ?? new List<Reserva>();
                }

                Console.WriteLine("Dados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar os dados: " + ex.Message);
            }
        }
    }
}