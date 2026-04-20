using System;
using InventorySystem.Models;


namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome = Console.ReadLine();
            int matricula = int.Parse(Console.ReadLine());

            Funcionario funcionario = new Funcionario(nome, matricula);

            Console.WriteLine(funcionario.ToString());

            Console.ReadKey();
        }
    }
}