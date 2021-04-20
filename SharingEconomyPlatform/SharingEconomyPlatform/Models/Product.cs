using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharingEconomyPlatform.Models
{
    public class Product
    {


        public int Id { get; set; }

        
        public string AddCategory { get; set; }
    }
    

}