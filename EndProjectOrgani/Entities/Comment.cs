using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(CommentValidation))]
    public class Comment:BaseEntity
    {
        public string Message { get; set; }

        public int BlogId { get; set; }
        public int SaleOffId { get; set; }

        //Relation Property

        public Blog Blog { get; set; }
        public SaleOff SaleOff { get; set; }
    }
}
