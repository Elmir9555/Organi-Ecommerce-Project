using System;
using System.ComponentModel.DataAnnotations;

namespace EndProjectOrgani.ViewModels.Accaunt
{
    public class ForgotPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
