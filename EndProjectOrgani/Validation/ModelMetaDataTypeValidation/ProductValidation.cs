using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.Validation.ModelMetaDataTypeValidation
{
    public class ProductValidation
    {

        [MaxLength(15, ErrorMessage = "Max 15 simvol ola biler.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alani bos kecmeyin.")]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
