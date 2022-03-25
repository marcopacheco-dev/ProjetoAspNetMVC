using System;
using System.Collections.Generic;

namespace ProjetoAspNetMVC.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        List<T> Consultar();
        T ObterPorId(Guid id);
    }
}
