using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(CommentValidation))]
    public class Comment:BaseEntity
    {
        public string Message { get; set; }

        public int ProductId { get; set; }
        public int SaleOffId { get; set; }

        //Relation Property
        
        public Product Product { get; set; }
        public SaleOff SaleOff { get; set; }
    }
}
