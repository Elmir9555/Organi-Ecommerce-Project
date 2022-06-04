using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class SaleOffValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}
