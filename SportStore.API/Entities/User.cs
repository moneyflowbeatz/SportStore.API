using System.ComponentModel.DataAnnotations;

namespace SportStore.API.Entities
{
    public class User
    {
        public Guid Id {get ;set;} = Guid.NewGuid();
    
        [MinLength(5,ErrorMessage = "Минимальное длина имени 5")]
        [SportStore.API.Validations.MaxLength(10)]
        public string Name {get ;set;} = string.Empty;
    }
}