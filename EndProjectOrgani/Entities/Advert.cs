using System;
using System.ComponentModel.DataAnnotations.Schema;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(AdvertValidation))]
    public class Advert:BaseEntity
    {
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
