using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharingEconomyPlatform.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        

        [Required]
        public ApplicationUser Customer { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}