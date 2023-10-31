using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do comentário é obrigatória !")]
        public string? Descricao { get; set; }


        //Referência tabela Consulta = FK
        [Required(ErrorMessage = "O id da consulta é obrigatório !")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }


        //Referência tabela Paciente = FK

        [Required(ErrorMessage = "O id do paciente é obrigatório !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
