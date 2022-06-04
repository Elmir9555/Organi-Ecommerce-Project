using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class BlogValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Image { get; set; }
    }
}
