using System.ComponentModel.DataAnnotations;

namespace Impacto_Solucoes_Digitais.Models
{
    public class Contato
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(200)]
        public string? Message { get; set; }
    }
}
