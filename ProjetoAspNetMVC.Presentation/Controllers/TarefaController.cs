using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetMVC.Models;
using ProjetoAspNetMVC.Presentation.Models;
using ProjetoAspNetMVC.Repository.Entities;
using ProjetoAspNetMVC.Repository.Interfaces;
using System;

namespace ProjetoAspNetMVC.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        //atributos
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaController(ITarefaRepository tarefaRepository,
     IUsuarioRepository usuarioRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }


        //método que tem a função de abrir a página de cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost] //método que tem a função de receber o POST do formulário
        public IActionResult Cadastro(TarefaCadastroModel model)
        {
            //verificar se todos os campos da model passaram nas validações
            if (ModelState.IsValid)
            {
                try
                {
                    //obter o email do usuario que esta autenticado no AspNet
                    var email = User.Identity.Name;
                    //buscar o usuario no banco de dados atraves do email
                    var usuario = _usuarioRepository.Obter(email);

                    //capturando os dados da tarefa
                    var tarefa = new Tarefa();

                    tarefa.Nome = model.Nome;
                    tarefa.Data = DateTime.Parse(model.Data);
                    tarefa.Hora = TimeSpan.Parse(model.Hora);
                    tarefa.Descricao = model.Descricao;
                    tarefa.Prioridade = model.Prioridade.ToString();
                    tarefa.IdUsuario = usuario.IdUsuario; //chave estrangeira
                                                          //cadastrando a tarefa
                    _tarefaRepository.Inserir(tarefa);

                    TempData["Mensagem"] = $"Tarefa {tarefa.Nome}, cadastrada com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        //método que tem a função de abrir a página de consulta
        public IActionResult Consulta()
        {
            try
            {
                //capturar o email do usuario autenticado..
                var email = User.Identity.Name;
                //obter os dados do usuario atraves do email..
                var usuario = _usuarioRepository.Obter(email);

                //consultar as tarefas do usuario autenticado
                var tarefas = _tarefaRepository.ConsultarPorUsuario(usuario.IdUsuario);

                //enviando a listagem de tarefas para a página
                return View(tarefas);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View();
        }

        //método para realizar a exclusão da tarefa
        public IActionResult Exclusao(Guid id)
        {
            try
            {
                //buscar a tarefa no banco de dados atraves do ID..
                var tarefa = _tarefaRepository.ObterPorId(id);
                //excluindo a tarefa
                _tarefaRepository.Excluir(tarefa);
                TempData["Mensagem"] = $"Tarefa {tarefa.Nome}, excluida com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            //redirecionamento para a página de consulta
            return RedirectToAction("Consulta");
        }

        //método para abrir a página de edição de tarefa
        public IActionResult Edicao(Guid id)
        {
            try
            {
                //buscar no banco de dados a tarefa atraves do ID
                var tarefa = _tarefaRepository.ObterPorId(id);

                //transferir os dados da tarefa para a classe model
                var model = new TarefaEdicaoModel();

                model.IdTarefa = tarefa.IdTarefa;
                model.Nome = tarefa.Nome;
                model.Data = tarefa.Data.ToString("yyyy-MM-dd");
                model.Hora = tarefa.Hora.ToString(@"hh\:mm");
                model.Descricao = tarefa.Descricao;
                model.Prioridade = (PrioridadeTarefa)Enum.Parse(typeof(PrioridadeTarefa), tarefa.Prioridade);

                return View(model); //enviando os dados para a página
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View();
        }

        [HttpPost]
        //método que irá receber o SUBMIT (envio dos dados do formulario)
        public IActionResult Edicao(TarefaEdicaoModel model)
        {
            //verificar se todos os campos da classe model
            //passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var tarefa = new Tarefa();

                    tarefa.IdTarefa = model.IdTarefa;
                    tarefa.Nome = model.Nome;
                    tarefa.Data = DateTime.Parse(model.Data);
                    tarefa.Hora = TimeSpan.Parse(model.Hora);
                    tarefa.Descricao = model.Descricao;
                    tarefa.Prioridade = model.Prioridade.ToString();

                    //atualizando a tarefa no repositorio
                    _tarefaRepository.Alterar(tarefa);

                    TempData["Mensagem"] = $"Tarefa {tarefa.Nome}, atualizada com sucesso.";

                    //redirecionando para a página de consulta
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    //exibir uma mensagem de erro
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }


    }
}
