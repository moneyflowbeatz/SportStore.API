
using System.ComponentModel.DataAnnotations;

namespace SportStore.API.Validations
{
    public class RoleValidator
    {
        
    }
    public class RoleMaxLengthAttribute : ValidationAttribute
{
    private readonly int _maxLength;

    public RoleMaxLengthAttribute(int maxLength) : base($"Name max {maxLength} ")
    {
        _maxLength = maxLength;
    }

    public override bool IsValid(object? value)
    {
        return ((String)value!).Length <= _maxLength;
    }
}
}