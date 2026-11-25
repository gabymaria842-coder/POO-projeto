using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GestaoEspacosDesportivos
{
    public class GestorSistema
    {
        public List<Utilizador> listaUtilizadores { get; set; } = new List<Utilizador>();
        public List<EspacoDesportivo> listaEspacos { get; set; } = new List<EspacoDesportivo>();
        public List<Reserva> listaReservas { get; set; } = new List<Reserva>();

        // Guarda quem tem sessão iniciada no momento (null se ninguém entrou)
        public Utilizador utilizadorAtual = null;

        private const string FicheiroUtilizadores = "utilizadores.json";
        private const string FicheiroEspacos = "espacos.json";
        private const string FicheiroReservas = "reservas.json";

        public GestorSistema()
        {
            CarregarDados();
        }

        // ---------- Adicionar (Com retorno bool e gravação automática) ----------

        public bool AdicionarUtilizador(Utilizador utilizador)
        {
            if (utilizador == null)
                return false;

            listaUtilizadores.Add(utilizador);
            GuardarDados();
            Console.WriteLine("Utilizador adicionado com sucesso.");
            return true;
        }

        // Registo com validação de campos e bloqueio de email duplicado
        public bool RegistarUtilizador(Utilizador novoUtilizador)
        {
            if (novoUtilizador == null || novoUtilizador.Email == null || novoUtilizador.Email.Trim() == "")
            {
                Console.WriteLine("Erro: Dados de utilizador inválidos.");
                return false;
            }

            foreach (Utilizador u in listaUtilizadores)
            {
                if (u.Email == novoUtilizador.Email)
                {
                    Console.WriteLine("Erro: Já existe um utilizador registado com este email.");
                    return false;
                }
            }

            listaUtilizadores.Add(novoUtilizador);
            GuardarDados();
            Console.WriteLine("Utilizador registado com sucesso.");
            return true;
        }

        public bool AdicionarEspaco(EspacoDesportivo espaco)
        {
            if (espaco == null)
                return false;

            listaEspacos.Add(espaco);
            GuardarDados();
            Console.WriteLine("Espaço desportivo adicionado com sucesso.");
            return true;
        }

        public bool AdicionarReserva(Reserva reserva)
        {
            if (reserva == null)
                return false;

            listaReservas.Add(reserva);
            GuardarDados();
            Console.WriteLine("Reserva adicionada com sucesso.");
            return true;
        }

        // ---------- Remover (Com gravação automática) ----------

        public bool RemoverUtilizador(string id)
        {
            for (int i = 0; i < listaUtilizadores.Count; i++)
            {
                if (listaUtilizadores[i].Id == id)
                {
                    if (utilizadorAtual != null && utilizadorAtual.Id == listaUtilizadores[i].Id)
                        utilizadorAtual = null;

                    listaUtilizadores.RemoveAt(i);
                    GuardarDados();
                    Console.WriteLine("Utilizador removido com sucesso.");
                    return true;
                }
            }
            return false;
        }

        public bool RemoverEspaco(int id)
        {
            for (int i = 0; i < listaEspacos.Count; i++)
            {
                if (listaEspacos[i].Id == id)
                {
                    listaEspacos.RemoveAt(i);
                    GuardarDados();
                    Console.WriteLine("Espaço removido com sucesso.");
                    return true;
                }
            }
            return false;
        }

        // ---------- Login e Sessão ----------

        public Utilizador FazerLogin(string email, string password)
        {
            if (email == "" || password == "")
            {
                Console.WriteLine("Erro: Preencha o email e a password.");
                utilizadorAtual = null;
                return null;
            }

            foreach (Utilizador u in listaUtilizadores)
            {
                if (u.Email == email && u.Password == password)
                {
                    utilizadorAtual = u;
                    Console.WriteLine("Login bem-sucedido! Bem-vindo, " + u.Nome);
                    return u;
                }
            }

            utilizadorAtual = null;
            Console.WriteLine("Erro: Email ou password incorretos.");
            return null;
        }

        public void TerminarSessao()
        {
            utilizadorAtual = null;
            Console.WriteLine("Sessão terminada.");
        }

        public bool UtilizadorAtualAdmin()
        {
            if (utilizadorAtual != null && utilizadorAtual.Perfil == "ADMIN")
            {
                return true;
            }
            return false;
        }

        // ---------- Persistência em ficheiros ----------

        public void GuardarDados()
        {
            try
            {
                var opcoes = new JsonSerializerOptions { WriteIndented = true };

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
                    List<Utilizador> dados = JsonSerializer.Deserialize<List<Utilizador>>(json);
                    if (dados != null)
                        listaUtilizadores = dados;
                }

                if (File.Exists(FicheiroEspacos))
                {
                    string json = File.ReadAllText(FicheiroEspacos);
                    List<EspacoDesportivo> dados = JsonSerializer.Deserialize<List<EspacoDesportivo>>(json);
                    if (dados != null)
                        listaEspacos = dados;
                }

                if (File.Exists(FicheiroReservas))
                {
                    string json = File.ReadAllText(FicheiroReservas);
                    List<Reserva> dados = JsonSerializer.Deserialize<List<Reserva>>(json);
                    if (dados != null)
                        listaReservas = dados;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar os dados: " + ex.Message);
            }
        }
    }
}