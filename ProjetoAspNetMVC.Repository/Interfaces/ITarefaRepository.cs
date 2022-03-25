using ProjetoAspNetMVC.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoAspNetMVC.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        void Inserir(Tarefa tarefa);
        void Alterar(Tarefa tarefa);
        void Excluir(Tarefa tarefa);
        List<Tarefa> ConsultarPorUsuario(Guid idUsuario);
        List<Tarefa> ConsultarPorUsuarioEPeriodo(Guid idUsuario, DateTime dataInicio, DateTime dataTermino);
        Tarefa ObterPorId(Guid idTarefa);

    }
}
