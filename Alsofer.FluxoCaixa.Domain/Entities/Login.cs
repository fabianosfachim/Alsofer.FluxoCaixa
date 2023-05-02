using System.ComponentModel.DataAnnotations;

namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class Login : EntityBase
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe email para login", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Login")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O Email deve ter no mínimo 4 e no máximo 50 caracteres.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string? email { get; set; }


        [Required(ErrorMessage = "Informe a password para login", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password Cliente")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A password deve ter no mínimo 6 e no máximo 50 caracteres.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string? password { get; set; }

       
        [DataType(DataType.Text)]
        public string? nome { get; set; }


        [DataType(DataType.Text)]
        public string? nmUsuarioCadastro { get; set; }


        [DataType(DataType.DateTime)]
        public  DateTime? dtCadastro { get; set; }


        [DataType(DataType.Text)]
        public string? nmUsuarioAlteracao { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? dtAlteracao { get; set; }

        public bool? ativo { get; set; }
    }
}