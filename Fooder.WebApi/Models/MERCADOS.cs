namespace Fooder.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MERCADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MERCADOS()
        {
            ESTOQUE = new HashSet<ESTOQUE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MERCADO_ID { get; set; }

        [StringLength(100)]
        public string NOME { get; set; }

        [StringLength(500)]
        public string MAPA { get; set; }

        [StringLength(255)]
        public string URL { get; set; }

        [StringLength(255)]
        public string URL_OFICIAL { get; set; }

        [StringLength(1000)]
        public string URL_MAPA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTOQUE> ESTOQUE { get; set; }
    }
}
