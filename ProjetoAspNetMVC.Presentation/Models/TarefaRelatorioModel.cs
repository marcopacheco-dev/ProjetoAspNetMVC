using System.ComponentModel.DataAnnotations;

namespace ProjetoAspNetMVC.Presentation.Models
{
    public class TarefaRelatorioModel
    {
        [Required(ErrorMessage = "Por favor, selecione a data de inicio.")]
        public string DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a data de término.")]
        public string DataTermino { get; set; }

    }
}
