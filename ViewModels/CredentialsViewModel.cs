using auth_angular.ViewModels.Validations;
using FluentValidation.Attributes;

namespace auth_angular.ViewModels
{
   [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel  
    {
            public string UserName { get; set; }
            public string Password { get; set; }        
    }
}