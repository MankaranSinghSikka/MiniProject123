using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharingEconomyPlatform.Models
{
    public class ProductAllList
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List<ApplicationUser> users { get; set; }
    }
    public class ProductAll
    {
        public Product product { get; set; }
        public Category categorie { get; set; }
        public ApplicationUser user { get; set; }
    }
}