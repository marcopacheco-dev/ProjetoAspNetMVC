﻿using System;

namespace ProjetoAspNetMVC.Repository.Entities
{
    public class Tarefa
    {
        public Guid IdTarefa { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public Guid IdUsuario { get; set; }

        //Relacionamento de Associação (TER-1)
        public Usuario Usuario { get; set; }

    }
}
