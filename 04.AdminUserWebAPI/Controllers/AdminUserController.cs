using _04.AdminUserWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _04.AdminUserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            AdminContext db = new AdminContext();
            List<AdminUser> adminUser = db.AdminUsers.ToList();
            return Ok(adminUser);
        }

        [HttpPost]
        public IActionResult AdminUserAdd(AdminUser adminUser)
        {
            AdminContext db = new AdminContext();
            db.AdminUsers.Add(adminUser);
            db.SaveChanges();

            if(adminUser == null)
            {
                return NotFound();
            }

            return Ok(adminUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdminContext db = new AdminContext();
            AdminUser adminUser = db.AdminUsers.FirstOrDefault( x => x.Id == id);

            if(adminUser == null)
            {
                return NotFound();
            }

            db.AdminUsers.Remove(adminUser);
            db.SaveChanges();
            return Ok(adminUser);
        }

        [HttpPut]

        public IActionResult Update(AdminUser adminUser)
        {
            AdminContext db = new AdminContext();
            AdminUser user = db.AdminUsers.FirstOrDefault( x => x.Id == adminUser.Id);

            if(user == null)
            {
                return NotFound();
            }

            user.Name = adminUser.Name;
            user.Surname = adminUser.Surname;
            user.Email = adminUser.Email;
            user.Phone = adminUser.Phone;

            db.SaveChanges();
            return Ok(user);
        }
    }
}
