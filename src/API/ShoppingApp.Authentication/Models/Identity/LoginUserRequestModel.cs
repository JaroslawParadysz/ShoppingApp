using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Authentication.Models.Identity
{
    public class LoginUserRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
