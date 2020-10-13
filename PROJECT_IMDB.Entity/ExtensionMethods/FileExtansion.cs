using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PROJECT_IMDB.Entity.ExtensionMethods
{
    public class FileExtansion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { ".jpg", ".png", ".jpeg" };
                bool result = extensions.Any(x => x.EndsWith(x));
                if (!result)
                {
                    return new ValidationResult("Allowed extensions are .jpg .png .jpeg");
                }
            }

            return ValidationResult.Success;
        }
    }
}
