using System;

namespace InventorySystem.Models
{
    public class Funcionario
    {
        public string Nome { get; private set; }
        public int Matricula { get; private set; }
        public Cargo Cargo { get; private set; }

        public Funcionario(string nome, int matricula, Cargo cargo)
        {
            Nome = nome;
            Matricula = matricula;
            Cargo = cargo;
        }

        public Funcionario(string nome, int matricula)
        {
            Nome = nome;
            Matricula = matricula;
            Cargo = Cargo.Operador;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nMatrícula: {Matricula}\nCargo: {Cargo}";
        }

        
        }
    }