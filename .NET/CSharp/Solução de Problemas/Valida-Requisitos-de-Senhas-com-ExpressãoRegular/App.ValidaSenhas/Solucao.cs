using System;
using System.Text.RegularExpressions;

namespace App.ValidaSenhas
{
    class Solucao
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                string senha = Console.ReadLine();

                if (string.IsNullOrEmpty(senha)) break;
                Regex rx = new Regex("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,32}$");
                Match match = rx.Match(senha);
                
                Console.WriteLine("Senha {0}.", match.Success ? "valida": "invalida"); 
            }  
        }
    }
}
