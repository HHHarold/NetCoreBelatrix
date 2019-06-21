using System.ComponentModel.DataAnnotations;

namespace Belatrix.WebApi.ViewModels
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
