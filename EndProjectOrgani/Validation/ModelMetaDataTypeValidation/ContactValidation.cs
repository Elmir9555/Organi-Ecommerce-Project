using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class ContactValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [EmailAddress(ErrorMessage = "Email formatinda simvol daxil edin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string OpenTime { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [MaxLength(15, ErrorMessage = "Max 15 simvol ola biler.")]
        public string Phone { get; set; }
    }
}
