using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Models
{
    public class GestaoFuncionarios
    {
        public List<Funcionario> ListaDeFuncionarios { get; private set; }
        public GestaoFuncionarios()
        {
            ListaDeFuncionarios = new List<Funcionario>();
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            ListaDeFuncionarios.Add(funcionario);
        }

        public Funcionario? RetornaFuncionario(int matricula)
        {
            return ListaDeFuncionarios.FirstOrDefault(funcionario => funcionario.Matricula == matricula);
        }

    }
}
