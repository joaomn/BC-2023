using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBlue.Models
{
    public class AgendaEntity
    {
        [Key]
        public int ID { get; set; }


        [Required (ErrorMessage =" Campo nome é obrigatório.")]
        [StringLength(255)] 
        public string Nome { get; set; }

        [Required (ErrorMessage ="Campo email é obrigatório.")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Campo telefone é obrigatório")]
        [StringLength(15)]
        [Column(name:"Telefone")]

        public string PhoneNumber { get; set; }




    }
}
