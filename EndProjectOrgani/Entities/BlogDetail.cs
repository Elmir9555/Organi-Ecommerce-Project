using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(BlogDetailsValidation))]
    public class BlogDetail:BaseEntity
    {
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Tags { get; set; }

        public int BlogId { get; set; }

        //Relation Property

        public Blog Blog { get; set; }
    }
}
