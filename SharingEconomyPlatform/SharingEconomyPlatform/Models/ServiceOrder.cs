using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharingEconomyPlatform.Models
{
    public class ServiceOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public Service Service { get; set; }

        public ApplicationUser Customer { get; set; }

        public ApplicationUser Vendor { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public char Status { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}