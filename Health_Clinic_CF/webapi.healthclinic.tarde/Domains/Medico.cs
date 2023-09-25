using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(10)")]
        [Required(ErrorMessage = "O CRM é obrigatório !")]
        public string? CRM { get; set; }


        //Referência tabela Usuario = FK
        [Required(ErrorMessage = "O id do usuário é obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        //Referência tabela Clinica = FK
        [Required(ErrorMessage = "O id da clinica é obrigatório !")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }


        //Referência tabela Especialidade = FK
        [Required(ErrorMessage = "O id da especialidade é obrigatório !")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}
