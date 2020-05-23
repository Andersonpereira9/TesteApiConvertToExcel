using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Validation.Pedido
{
    public class ImportarPedidoValidator : AbstractValidator<List<PedidoModel>>
    {
        public override ValidationResult Validate(ValidationContext<List<PedidoModel>> context)
        {
            Pedidos();
            return base.Validate(context);
        }

        private void Pedidos()
        {

            //RuleFor(f => f)
            //  .NotNull().WithMessage("O arquivo é inválido");

            //RuleFor(f => f)
            //    .Must(m => m.Contains(c => c.DataEntrega <= DateTime.Now))
            //    .WithMessage( w => w.Where(w => w.DataEntrega <= DateTime.Now).FirstOrDefault().Id)
            //    .Must(m => Path.GetExtension(m).Equals(".xlsx", StringComparison.OrdinalIgnoreCase)).WithMessage("O formato do arquivo inválido");

        }
    }
}
