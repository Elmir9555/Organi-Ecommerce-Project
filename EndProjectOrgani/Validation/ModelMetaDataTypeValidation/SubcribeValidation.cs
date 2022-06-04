using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class SubcribeValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [EmailAddress(ErrorMessage = "Email formatinda yazi daxil edin.!")]
        public string Email { get; set; }
    }
}
