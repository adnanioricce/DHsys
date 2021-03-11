using System.ComponentModel.DataAnnotations;
using DAL.Identity;

namespace Api.Controllers.Authentication.Models
{
    public class LoginRequest
    {                
        [StringLength(255)]
        public string UserName { get; set; }
        [StringLength(255)]        
        public string Password { get; set; }        
    }
}