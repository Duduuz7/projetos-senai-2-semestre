using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatório !")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório !")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O endereço é obrigatório !")]
        public string? Endereco { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de abertura é obrigatório !")]
        public TimeOnly HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de fechamento é obrigatório !")]
        public TimeOnly HorarioFechamento { get; set; }
    }
}
