using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(CommentValidation))]
    public class Comment:BaseEntity
    {
        public string Message { get; set; }
        public string ByName { get; set; }
        public int ProductId { get; set; }
        
        //Relation Property
        
        public Product Product { get; set; }
        
    }
}
