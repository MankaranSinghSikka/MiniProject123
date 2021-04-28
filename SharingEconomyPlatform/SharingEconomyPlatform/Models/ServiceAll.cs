using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharingEconomyPlatform.Models
{
    public class ServiceAllList
    {
        public List<Service> services { get; set; }
        public List<Category> categories { get; set; }
        public List<ApplicationUser> users { get; set; }
    }
    public class ServiceAll
    {
        public Service service { get; set; }
        public Category categorie { get; set; }
        public ApplicationUser user { get; set; }
    }
}