﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Shared.CustomValidation
{
    public class EmailDomainValidation : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@');
                if (strings.Length > 1 && strings[1].ToUpper() == AllowedDomain.ToUpper())
                {
                    return null;
                }
                return new ValidationResult($"Domain must be {AllowedDomain}",
                                            new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
