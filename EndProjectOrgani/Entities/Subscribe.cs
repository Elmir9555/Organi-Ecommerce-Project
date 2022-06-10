using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(SubcribeValidation))]
    public class Subscribe:BaseEntity
    {
            public string Email { get; set; }       
    }
}
