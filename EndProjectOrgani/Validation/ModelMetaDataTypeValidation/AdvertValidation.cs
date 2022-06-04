using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class AdvertValidation
    {
        [Required]
        public string Image { get; set; }
    }
}
