using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(7)")]
        [Required(ErrorMessage = "RG obrigatório !")]
        public string? RG { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF obrigatório !")]
        public string? CPF { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento obrigatória !")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(13)")]
        [Required(ErrorMessage = "Telefone obrigatório !")]
        public string? Telefone { get; set; }

        //Referência tabela Usuario = FK
        [Required(ErrorMessage = "O id do usuário é obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
