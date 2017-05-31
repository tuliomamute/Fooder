namespace Fooder.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTOQUE")]
    public partial class ESTOQUE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRODUTO_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MERCADO_ID { get; set; }

        [StringLength(20)]
        public string ULTIMA_ATUALIZACAO { get; set; }

        public decimal? PRECO { get; set; }

        public virtual MERCADOS MERCADOS { get; set; }

        public virtual PRODUTOS PRODUTOS { get; set; }
    }
}
