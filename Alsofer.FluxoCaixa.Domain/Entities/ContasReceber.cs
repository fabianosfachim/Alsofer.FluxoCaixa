using System.ComponentModel.DataAnnotations;

namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class ContasReceber : EntityBase
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int idCliente { get; set; }

        [Required]
        public int idReceita { get; set; }

        [Required]
        public int idStatus { get; set; }

        [Required(ErrorMessage = "Informe a descrição de contas a receber", AllowEmptyStrings = false)]
        [Display(Name = "Descrição Contas Receber")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "A descrição de contas a receber deve ter no mínimo de 10 cracteres.")]
        [DataType(DataType.Text)]
        public string? descricaoContasReceber { get; set; }

        [Required(ErrorMessage = "Informe a data de pagamento", AllowEmptyStrings = false)]
        [Display(Name = "Data de pagamento")]
        [DataType(DataType.DateTime)]
        public DateTime? dtPagamento { get; set; }

        [Required(ErrorMessage = "Informe o valor do pagamento", AllowEmptyStrings = false)]
        [Display(Name = "Valor de pagamento")]
        [DataType(DataType.Currency)]
        public decimal? vlPagamento { get; set; }

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

    }
}
