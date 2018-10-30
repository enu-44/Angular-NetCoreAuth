using Microsoft.AspNetCore.Identity;

namespace auth_angular.Models.Entities
{
    public class AppUser: IdentityUser
    {
        // Extended Properties
       public string FirstName { get; set; }
       public string LastName { get; set; }       
    }
}