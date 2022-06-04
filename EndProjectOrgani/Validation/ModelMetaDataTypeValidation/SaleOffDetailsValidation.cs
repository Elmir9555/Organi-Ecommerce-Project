using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class SaleOffDetailsValidation
    {
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        [MaxLength(2500, ErrorMessage = "Max 2500 simvol ola biler.")]
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int StarCount { get; set; }
        public bool Availability { get; set; }
    }
}
