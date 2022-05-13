using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Ubuntu.Models
{
    public class Ubuntu //: IEntityTypeConfiguration<Linguagem>
    {
        public int Id { get; set; }

        public string Zero = "0000";
        
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter um comprimento mínimo de 3 letras e máximo de 200.")]
        [Required(ErrorMessage = "Digite o nome do ubuntu")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digitesua idade")]
        [Range(1, 100, ErrorMessage = "Esse campo aceita apenas números")]
        public string Idade { get; set; }

        [Required(ErrorMessage = "Digite o número do seu RG")]
        [Range(1, 1000000000000000, ErrorMessage = "Esse campo aceita apenas números")]
        public string Rg { get; set; }

        //public Guid ConhecimentoId { get; set; }
        //public virtual Linguagem linguagem { get; set; }

        public Ubuntu() { }
       // public string Status { get; set; }

        public Ubuntu(int id, string nome, string idade, string rg, string zero)//string status)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Rg = rg;
            Zero = zero;
            //Status = status;

         }




        //public void Configure(EntityTypeBuilder<Linguagem> builder)
        //{
        //    builder.HasKey(c => c.Id);
        //    builder.Property(x => x.Id).IsRequired();
        //}
    }
}
