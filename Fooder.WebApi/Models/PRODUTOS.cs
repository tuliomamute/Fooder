namespace Fooder.WebApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    public partial class PRODUTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUTOS()
        {
            ESTOQUE = new HashSet<ESTOQUE>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRODUTO_ID { get; set; }

        [StringLength(100)]
        public string NOME { get; set; }

        public int? CATEGORIA_ID { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual CATEGORIAS CATEGORIAS { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTOQUE> ESTOQUE { get; set; }
    }
}
