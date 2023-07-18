using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<Users> userList = new List<Users>();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            UsersDBConn dBConn = new UsersDBConn();
            // var userList = dBConn.Users;            
            var userList = dBConn.Users.Where(x => x.UserType != "Admin");
            return userList.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UsersDBConn dBConn = new UsersDBConn();
            var record = dBConn.Users.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                return Ok(record);
            }

            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            UsersDBConn dBConn = new UsersDBConn();
            dBConn.Users.Add(user);
            dBConn.SaveChanges();

            if (user.Id >0)
            {
                return Ok();
                //return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }

            return BadRequest("Failed to create user.");
        }


        // PUT api/<UsersController>/5
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users updatedUser)
        {
            UsersDBConn dBConn = new UsersDBConn();
            var user = dBConn.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
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

                dBConn.SaveChanges();
                return Ok(user);
            }

            return NotFound();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsersDBConn dBConn = new UsersDBConn();
            var user = dBConn.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                dBConn.Users.Remove(user);
                dBConn.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }
    }
}
