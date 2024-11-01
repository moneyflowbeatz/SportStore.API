using System.ComponentModel.DataAnnotations;


namespace SportStore.API.Entities
{
    public class Role
    {
        public Guid Id {get ;set;} = Guid.NewGuid();
    
        [MinLength(5,ErrorMessage = "Минимальное длина роли 5")]
        [SportStore.API.Validations.MaxLength(10)]
        public string Name {get ;set;} = string.Empty;
    }
}