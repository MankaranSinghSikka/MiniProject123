using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharingEconomyPlatform.Models
{
    public class Service
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public bool Available { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string AvailableLocation { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public ApplicationUser Vendor { get; set; }
    }
}