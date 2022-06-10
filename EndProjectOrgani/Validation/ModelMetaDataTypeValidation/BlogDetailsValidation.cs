using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class BlogDetailsValidation
    {
        [Required(ErrorMessage = "Description bos kecmeyin.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "CategoryName bos kecmeyin.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Tags bos kecmeyin.")]
        public string Tags { get; set; }
    }
}
