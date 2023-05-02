using System.ComponentModel.DataAnnotations;

namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class ContasPagar :EntityBase
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int idFornecedor { get; set; }

        [Required]
        public int idDespesa { get; set; }

        [Required]
        public int idStatus { get; set; }

        [Required(ErrorMessage = "Informe a descrição de contas a pagar", AllowEmptyStrings = false)]
        [Display(Name = "Descrição Contas Pagar")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "A descrição de contas a pagar deve ter no mínimo de 10 cracteres.")]
        [DataType(DataType.Text)]
        public string? descricaoContaPagar { get; set; }

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
