using Cadastro_Ubuntu.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Ubuntu.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter um comprimento mínimo de 3 letras e máximo de 200.")]
        [Required(ErrorMessage = "Digite o nome do usuário")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome do login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
