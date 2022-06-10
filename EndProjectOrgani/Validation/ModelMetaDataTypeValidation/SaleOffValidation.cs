using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class SaleOffValidation
    {
        [Required(ErrorMessage = "Name bos kecmeyin.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "OldPrice bos kecmeyin.")]
        public decimal OldPrice { get; set; }
        [Required(ErrorMessage = "NewPrice bos kecmeyin.")]
        public decimal NewPrice { get; set; }
    }
}
