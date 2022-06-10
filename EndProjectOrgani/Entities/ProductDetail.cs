using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(ProductDetailsValidation))]
    public class ProductDetail:BaseEntity
    {
       
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int StarCount { get; set; }
        public bool Availability { get; set; }

        public int ProductId { get; set; }

        //Relation Property

        public Product Product { get; set; }
    }
}
