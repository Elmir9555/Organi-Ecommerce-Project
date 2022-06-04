using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class BlogDetailsValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Tags { get; set; }
    }
}
