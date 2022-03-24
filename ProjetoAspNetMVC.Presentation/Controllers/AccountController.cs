﻿using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetMVC.Presentation.Models;
using ProjetoAspNetMVC.Repository.Entities;
using ProjetoAspNetMVC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC.Presentation.Controllers
{
    public class AccountController : Controller
    {
        //atributo para acessar os métodos do repositorio (IUsuarioRepository)
        private readonly IUsuarioRepository _usuarioRepository;

        //método construtor atraves do qual do AspNet MVC irá inicializar
        //a interface IUsuarioRepository (injeção de dependencia)
        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //método utilizado para abrir a página de Login
        public IActionResult Login()
        {
            return View();
        }

        //método executado pelo formulário da página
        //chamado pelo SUBMIT (HTTP POST)
        [HttpPost]
        public IActionResult Login(AccountLoginModel model)
        {
            //verificar se todos os campos passaram
            //nas regras de validação com sucesso!
            if (ModelState.IsValid)
            {
                try
                {
                    //consultar o usuario no banco de dados 
                    //atraves do email e senha
                    var usuario = _usuarioRepository.Obter(model.Email, model.Senha);

                    //verificar se o usuario foi encontrado
                    if (usuario != null)
                    {
                        //IREMOS AUTENTICAR O USUARIO!!
                    }
                    else
                    {
                        TempData["Mensagem"] = "Acesso negado.";
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro: " + e.Message;
                }
            }

            return View();
        }

        //método para abrir a página /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] //receber os campos enviados pelo SUBMIT do formulário
        public IActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario();

                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;

                    //verificar se o email informado já existe no banco de dados
                    if (_usuarioRepository.Obter(usuario.Email) != null)
                    {
                        TempData["Mensagem"] = "O email informado já encontra-se cadastrado.";
                    }
                    else
                    {
                        _usuarioRepository.Inserir(usuario);

                        TempData["Mensagem"] = $"Usuário {usuario.Nome}, cadastrado com sucesso!";
                        ModelState.Clear(); //limpar os campos do formulário
                    }
                }
                catch (Exception e)
                {
                    //gerar uma mensagem de erro..
                    TempData["Mensagem"] = "Erro: " + e.Message;
                }
            }
          return View();
        }
    }
}
