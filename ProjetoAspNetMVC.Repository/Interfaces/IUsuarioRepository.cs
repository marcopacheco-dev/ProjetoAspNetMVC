﻿using ProjetoAspNetMVC.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);

        List<Usuario> Consultar();
        Usuario ObterPorId(Guid idUsuario);

        Usuario Obter(string email);
        Usuario Obter(string email, string senha);
    }
}
