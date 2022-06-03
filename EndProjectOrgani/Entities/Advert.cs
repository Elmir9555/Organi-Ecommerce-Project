using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EndProjectOrgani.Entities
{
    public class Advert:BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
