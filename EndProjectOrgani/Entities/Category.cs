﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
   
    public class Category:BaseEntity
    {
       
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        //Relation Property
        public List<Product> Products { get; set; }

    }
}
