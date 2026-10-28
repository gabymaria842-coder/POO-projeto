using System;

public class Administrador : Utilizador //herança
{
    public Administrador(string id, string nome, string email, string password) 
        : base(id, nome, email, password, "ADMIN") 
    {
    }

    public void AprovarReserva() //para ja fica vazia
    {
        
    }
}