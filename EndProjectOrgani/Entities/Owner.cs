﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EndProjectOrgani.Entities
{
    public class Owner:BaseEntity
    {
        public string Fullname { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Profession { get; set; }


        //Relation Property

        public Blog Blog { get; set; }
    }
}