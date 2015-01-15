using System;
using SuporteSF.Domain.Entities;
using SuporteSF.Domain.Interfaces.Specification;

namespace SuporteSF.Domain.Specification
{
    class SuporteEstaCadastradoMaisDeCincoAnos : ISpecification<Suporte>
    {
        public bool IsSatisfiedBy(Suporte model)
        {
            return DateTime.Now.Year - model.DtAbertura.Year >= 5;
        }
    }
}
