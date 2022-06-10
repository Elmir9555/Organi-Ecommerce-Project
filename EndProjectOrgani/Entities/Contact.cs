﻿using System;
using EndProjectOrgani.Validation.ModelMetaDataTypeValidation;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.Entities
{
    [ModelMetadataType(typeof(ContactValidation))]
    public class Contact:BaseEntity
    {
        public string Email { get; set; }
        public string Adress { get; set; }
        public string OpenTime { get; set; }
        public string Phone { get; set; }
    }
}
