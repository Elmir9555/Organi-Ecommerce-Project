using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class OwnerValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [MaxLength(35, ErrorMessage = "Max 35 simvol ola biler.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Image { get; set; }
    }
}
