using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EndProjectOrgani.Entities
{
    public class SaleOff:BaseEntity
    {
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }


        //Relation Property
        public List<Comment> Comments { get; set; }
        public SaleOffDetail SaleOffDetails { get; set; }
    }
}
