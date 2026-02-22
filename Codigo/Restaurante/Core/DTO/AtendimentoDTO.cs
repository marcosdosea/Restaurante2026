using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AtendimentoDTO
    {
        [Display(Name = "Código")]
        public uint Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Início")]
        public DateTime DataHoraInicio { get; set; }

        /// <summary>
        /// I - INICIADO
        /// C- CANCELADO
        /// F - FINALIZADO
        /// </summary>
        public string Status { get; set; } = null!;

        [Display(Name = "Status")]
        public string StatusDescricao
        {
            get
            {
                return Status switch
                {
                    "I" => "INICIADO",
                    "C" => "CANCELADO",
                    "F" => "FINALIZADO",
                    _ => Status
                };
            }
        }

        [Display(Name = "Código da Mesa")]
        public int IdMesa { get; set; }
    }
}
