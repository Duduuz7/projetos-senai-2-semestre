using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do agendamento é obrigatória !")]
        public DateTime DataAgendamento { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário do agendamento é obrigatório !")]
        public TimeSpan HorarioAgendamento { get; set; } = new TimeSpan(1); 


        //Referência tabela Paciente = FK

        [Required(ErrorMessage = "O id do paciente é obrigatório !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        //Referência tabela Medico = FK

        [Required(ErrorMessage = "O id do médico é obrigatório !")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
