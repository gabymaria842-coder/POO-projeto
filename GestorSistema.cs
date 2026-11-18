using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public GestorSistema()
        {
            // Carrega os dados automaticamente assim que o gestor é criado
            CarregarDados();
        }

        // ---------- Adicionar (Com retorno bool e gravação automática) ----------

        public bool AdicionarUtilizador(Utilizador utilizador)
        {
            listaUtilizadores.Add(utilizador);
            GuardarDados(); // Guarda logo no JSON
            Console.WriteLine("Utilizador adicionado com sucesso.");
            return true;
        }

        public bool AdicionarEspaco(EspacoDesportivo espaco)
        {
            listaEspacos.Add(espaco);
            GuardarDados(); // Guarda logo no JSON
            Console.WriteLine("Espaço desportivo adicionado com sucesso.");
            return true;
        }

        public bool AdicionarReserva(Reserva reserva)
        {
            listaReservas.Add(reserva);
            GuardarDados(); // Guarda logo no JSON
            Console.WriteLine("Reserva adicionada com sucesso.");
            return true;
        }

        // ---------- Remover (Com gravação automática) -------

        public bool RemoverUtilizador(string id)
        {
            Utilizador u = listaUtilizadores.Find(x => x.id == id);
            if (u != null)
            {
                listaUtilizadores.Remove(u);
                GuardarDados(); // Atualiza o JSON
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
                GuardarDados(); // Atualiza o JSON
                Console.WriteLine("Espaço removido com sucesso.");
                return true;
            }
            return false;
        }

        // ---------- Autenticação / Login (Essencial para a tua parte) ----------

        public Utilizador FazerLogin(string email, string password)
        {
            // Procura o utilizador pelo email e password
            Utilizador user = listaUtilizadores.FirstOrDefault(u => u.email == email && u.password == password);

            if (user != null)
            {
                Console.WriteLine($"Login bem-sucedido! Bem-vindo, {user.nome}");
                return user;
            }

            Console.WriteLine("Erro: Email ou password incorretos.");
            return null;
        }

        // ---------- Persistência em ficheiros (Corrigido com Indentação) ----------

        public void GuardarDados()
        {
            try
            {
                var opcoes = new JsonSerializerOptions { WriteIndented = true }; // Identação ativada!

                
                File.WriteAllText(FicheiroUtilizadores, JsonSerializer.Serialize(listaUtilizadores, opcoes));
                File.WriteAllText(FicheiroEspacos, JsonSerializer.Serialize(listaEspacos, opcoes));
                File.WriteAllText(FicheiroReservas, JsonSerializer.Serialize(listaReservas, opcoes));
                
                
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar os dados: " + ex.Message);
            }
        }
    }
}