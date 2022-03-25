using System.ComponentModel.DataAnnotations;

namespace ProjetoAspNetMVC.Models
{
    public class TarefaCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data da tarefa.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe o hora da tarefa.")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a prioridade da tarefa.")]
        public PrioridadeTarefa Prioridade { get; set; }
    }

    //utilizando para gerar um campo de opções
    public enum PrioridadeTarefa
    {
        ALTA,
        MEDIA,
        BAIXA
    }
}

