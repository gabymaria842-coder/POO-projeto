using System;

//classes utilizador (herança)(subclass UtilizadorNormal & Administrador)

public class utilizador
{
    public string id {get;  private  set;}
    public string nome {get; private set;}
    public string email {get; private set;}
    public string perfil {get;  private set;}
    public string password {get; private set;}

    public Utilizador(string id, string nome, string email, string password, string perfil) 
    {
        Id = id;
        Nome = nome;
        Email = email;
        Password = password;
        Perfil = perfil;
    }
    
    public Utilizador(string email, string password) //só recebe email e passwords
    {
        Id = "00";
        Nome = "Utilizador Temporário";
        Email = email;
        Password = password;
        Perfil = "NORMAL";
    }

    public void Set_Nome(string NovoNome) //apenas para mudar o nome do utilizador
    {
        Nome = novoNome;
        Console.WriteLine($"Perfil atualizado para o novo nome: {Nome}");//é para mostrar o nome novo 
    }

    public void set_Password(string novaPassword) 
    {
        Password = novaPassword;
        Console.WriteLine("Perfil e password atualizados com sucesso para!"); //aqui nao mostra a pass nova para mostrar é {this.password}
    }

    public void Set_Email(string novoEmail) 
    {
        if (novoEmail.Contains("@")) // validação 
        {
            this.email = novoEmail;
            Console.WriteLine($"Email atualizado para: {novoEmail}");
        }
    }


    public bool Autenticar(string emailInput, string passInput) 
    {
        return email == emailInput && password == passInput; 
    }



}