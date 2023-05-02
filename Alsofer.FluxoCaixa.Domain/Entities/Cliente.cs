using System.ComponentModel.DataAnnotations;

namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class Cliente : EntityBase
    {

        [Required]
        public int id { get; set; }


        [Required(ErrorMessage = "Informe o nome do cliente",  AllowEmptyStrings = false)]
        [Display(Name = "Nome do Cliente")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "O nome do cliente deve ter no mínimo 4 e no máximo 150 caracteres.")]
        [DataType(DataType.Text)]
        public string? nomeCliente { get; set; }

        [Required(ErrorMessage = "Informe cnpj OU CPF cliente", AllowEmptyStrings = false)]
        [Display(Name = "CPF/CNPJ Cliente")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O cnpj deve ter no mínimo 11 e no máximo 15 caracteres.")]
        [DataType(DataType.Text)]
        public string? cpfCnpj { get; set; }

        [Required(ErrorMessage = "Informe email do cliente", AllowEmptyStrings = false)]
        [Display(Name = "Email Cliente")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O Email deve ter no mínimo 4 e no máximo 50 caracteres.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [DataType(DataType.Text)]
        public string? email   { get; set; }


        [Required(ErrorMessage = "Informe o ddd do seu telefone,  AllowEmptyStrings = false")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O ddd deve ter no mínimo 3 e no máximo 3 caracteres.")]
        [DataType(DataType.Text)]
        public string? ddd { get; set; }


        [Required(ErrorMessage = "Informe o seu telefone,  AllowEmptyStrings = false")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "O telefone deve ter no mínimo 7 e no máximo 15 caracteres.")]
        [DataType(DataType.Text)]
        public string? telefone { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string? nmUsuarioCadastro { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? dtCadastro { get; set; }


        [DataType(DataType.Text)]
        public string? nmUsuarioAlteracao { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? dtAlteracao { get; set; }


        public bool ativo { get; set; }
  

    }
}
