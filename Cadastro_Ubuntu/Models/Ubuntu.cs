using System.ComponentModel.DataAnnotations;

namespace Cadastro_Ubuntu.Models
{
    public class Ubuntu
    {
        public int Id { get; set; }

        public string Zero = "0000";

        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter um comprimento mínimo de 3 letras e máximo de 200.")]
        [Required(ErrorMessage = "Digite o nome do ubuntu")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite uma linguagem")]
        public string Linguagem { get; set; }

        [Required(ErrorMessage = "Digite seu nivel de conhecimento na linguagem escolhida")]
        [Range(1, 10, ErrorMessage = "Digite um número de 0 a 10")]
        public string Nivel { get; set; }

        public Ubuntu() { }
       // public string Status { get; set; }

        public Ubuntu(int id, string nome, string linguagem, string nivel, string zero)//string status)
        {
            Id = id;
            Nome = nome;
            Linguagem = linguagem;
            Nivel = nivel;
            Zero = zero;
            //Status = status;

         }
    }
}
