using System;

public class UtilizadorNormal : Utilizador //herança
{
    public UtilizadorNormal(string id, string nome, string email, string password) 
        : base(id, nome, email, password, "NORMAL") 
    {
    }

    public void CriarReserva() //para ja fica vazia
    {
       
    }
}