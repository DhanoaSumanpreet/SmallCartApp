namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Product")]
    public partial class Product:Entity
    {        
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
