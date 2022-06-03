﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EndProjectOrgani.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public int OwnerId { get; set; }

        //Relation Property

        public List<Comment> Comments { get; set; }
        public Owner Owner { get; set; }
        public BlogDetail BlogDetails { get; set; }
    }
}