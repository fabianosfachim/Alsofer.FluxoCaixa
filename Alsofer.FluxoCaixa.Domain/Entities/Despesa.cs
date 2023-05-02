using System.ComponentModel.DataAnnotations;


namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class Despesa : EntityBase
    {
        [Required]
        public int id { get; set; }


        [Required(ErrorMessage = "Informe o nome da despesa", AllowEmptyStrings = false)]
        [Display(Name = "Nome da Despesa")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome da despesa deve ter no mínimo 5 e no máximo 100 caracteres.")]
        [DataType(DataType.Text)]
        public string? nomeDespesa { get; set; }

        [Required(ErrorMessage = "Informe a descrição da despesa", AllowEmptyStrings = false)]
        [Display(Name = "Descrição da despesa")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O descrição da despesa deve ter no mínimo 5 e no máximo 250 caracteres.")]
        [DataType(DataType.Text)]
        public string? descricaoDespesa { get; set; }

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
