using System;

namespace InventorySystem.Models
{
    public abstract class Funcionario
    {
        public string Nome { get; private set; }
        public int Matricula { get; private set; }

        public Funcionario(string nome, int matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nMatrícula: {Matricula}";
        }

        
        }
    }