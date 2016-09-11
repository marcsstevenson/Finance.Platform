using System.ComponentModel.DataAnnotations;

namespace Generic.Framework.Interfaces.Personal
{
    public interface IFirstName
    {
        [Required]
        string FirstName { get; set; }
    }
}
