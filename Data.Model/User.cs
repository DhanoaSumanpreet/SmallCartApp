namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("User")]
    public partial class User:Entity
    {        
        public User()
        {
            Carts = new HashSet<Cart>();
        }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
                
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
