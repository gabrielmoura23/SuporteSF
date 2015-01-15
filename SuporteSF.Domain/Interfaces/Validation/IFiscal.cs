using SuporteSF.Domain.ValueObjects;

namespace SuporteSF.Domain.Interfaces.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
