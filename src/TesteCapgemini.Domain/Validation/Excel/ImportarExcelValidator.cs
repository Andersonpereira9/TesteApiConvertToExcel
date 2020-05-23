using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace TesteCapgemini.Domain.Validation.Excel
{
    public class ImportarExcelValidator : AbstractValidator<IFormFile>
    {
        public override ValidationResult Validate(ValidationContext<IFormFile> context)
        {
            Excel();
            return base.Validate(context);
        }

        private void Excel()
        {

            RuleFor(f => f.Length)               
              .NotNull().WithMessage("O arquivo é inválido");

            RuleFor(f => f.FileName)
               .NotEmpty().WithMessage("O nome do arquivo é inválido")
               .Must(m => Path.GetExtension(m).Equals(".xlsx", StringComparison.OrdinalIgnoreCase)).WithMessage("O formato do arquivo inválido");

        }
    }
}
