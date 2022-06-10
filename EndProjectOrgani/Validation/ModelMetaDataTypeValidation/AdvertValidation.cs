using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class AdvertValidation
    {
        [Required(ErrorMessage = "Photo bos kecmeyin.")]
        public IFormFile Photo { get; set; }
    }
}
