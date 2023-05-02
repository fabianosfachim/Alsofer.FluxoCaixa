using System.ComponentModel.DataAnnotations;

namespace Alsofer.FluxoCaixa.Domain.Entities
{
    public class Status : EntityBase
    {
        public int id { get; set; }


        [DataType(DataType.Text)]
        public string ? nomeStatus { get; set; }

        [DataType(DataType.Text)]
        public string? nmUsuarioCadastro { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? dtCadastro { get; set; }


        [DataType(DataType.Text)]
        public string? nmUsuarioAlteracao { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? dtAlteracao { get; set; }

        public bool? ativo { get; set; }
    }
}
