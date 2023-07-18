using AdmissionApps;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestApplicationAPI;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AdmissionDbContext _dbContext;

        public AccountController(AdmissionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult Get()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        // GET api/Account/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/Account
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsersViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsersViewModel updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.MobileNo = updatedUser.MobileNo;
            user.Password = updatedUser.Password;
            user.EmailId = updatedUser.EmailId;
            user.UserType = updatedUser.UserType;
            user.CreationTime = updatedUser.CreationTime;
            user.FatherName = updatedUser.FatherName;
            user.MotherName = updatedUser.MotherName;
            user.Address = updatedUser.Address;
            user.State = updatedUser.State;
            user.City = updatedUser.City;
            user.Pincode = updatedUser.Pincode;
            user.CourseName = updatedUser.CourseName;
            user.AdmissionStatus = updatedUser.AdmissionStatus;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
