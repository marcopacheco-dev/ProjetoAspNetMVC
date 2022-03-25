using System;
using System.Collections.Generic;

namespace ProjetoAspNetMVC.Repository.Entities
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        //Relacionamento de Associação (TER-MUITOS)
        public List<Tarefa> Tarefas { get; set; }

    }

}
