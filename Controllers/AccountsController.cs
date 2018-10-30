using System.Threading.Tasks;
using auth_angular.Data;
using auth_angular.Helper;
using auth_angular.Models.Entities;
using auth_angular.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace auth_angular.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController:Controller
    {
        #region Atributes
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        #endregion


        #region Constructor

        public AccountsController(UserManager<AppUser> userManager,IMapper mapper,ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper=mapper;
            _appDbContext=appDbContext;
        }

        #endregion 


        //POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity=_mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.JobSeekers.AddAsync(new JobSeeker{IdentityId=userIdentity.Id, Location=model.Location});
            await _appDbContext.SaveChangesAsync();
            
            return new OkObjectResult("Account created");
        }


         [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hola");
        }
    }
}