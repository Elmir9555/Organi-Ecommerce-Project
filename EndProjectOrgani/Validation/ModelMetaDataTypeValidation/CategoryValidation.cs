using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class CategoryValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Name { get; set; }

        public string Image { get; set; }
    }
}
