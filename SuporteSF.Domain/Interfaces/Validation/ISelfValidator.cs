using SuporteSF.Domain.ValueObjects;

namespace SuporteSF.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid(); 
    }
}