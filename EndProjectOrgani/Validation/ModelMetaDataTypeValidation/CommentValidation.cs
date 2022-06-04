using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class CommentValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [MaxLength(1500, ErrorMessage = "Max 1500 simvol ola biler.")]
        public string Message { get; set; }
    }
}
