using System;

public class Utilizador
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Perfil { get; set; }
    public string Password { get; set; }

    // Construtor vazio normal (usado automaticamente ao ler o JSON)
    public Utilizador()
    {
    }

    public Utilizador(string id, string nome, string email, string password, string perfil)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Password = password;
        Perfil = perfil;
    }

    public Utilizador(string email, string password) // só recebe email e password
    {
        Id = "00";
        Nome = "Utilizador Temporário";
        Email = email;
        Password = password;
        Perfil = "NORMAL";
    }

    public void Set_Nome(string novoNome)
    {
        Nome = novoNome;
        Console.WriteLine($"Perfil atualizado para o novo nome: {Nome}");
    }

    public void Set_Password(string novaPassword)
    {
        Password = novaPassword;
        Console.WriteLine("Password atualizada com sucesso!");
    }

    public void Set_Email(string novoEmail)
    {
        if (novoEmail != "" && novoEmail.Contains("@"))
        {
            Email = novoEmail;
            Console.WriteLine($"Email atualizado para: {Email}");
        }
        else
        {
            Console.WriteLine("Email inválido.");
        }
    }

    public bool Autenticar(string emailInput, string passInput)
    {
        return Email == emailInput && Password == passInput;
    }
}