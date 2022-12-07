using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_EMS.Models;

namespace Web_Api_EMS.Controllers
{
    public class Api_UserMasterController : ApiController
    {
        EMS_ProjectDBEntities2 db = new EMS_ProjectDBEntities2();
    
        //Get all Users
        public IEnumerable<User_Master> Get()
        {
            return db.User_Master.ToList();
        }

        //Post or add new User
        public IHttpActionResult PostNewUser([FromBody] User_Master um)
        {
            if (!ModelState.IsValid)
                return BadRequest("Validations Failed");
            db.User_Master.Add(new User_Master()
            {
                UserID = um.UserID,
                UserName = um.UserName,
                UserPassword = um.UserPassword,
                UserType = um.UserType,
            });
            db.SaveChanges();
            return Ok(um);
        }


        //Get the Particular User Details by Id
        public User_Master Get(string id)
        {
            User_Master um = db.User_Master.Find(id);
            return (um);
        }


        //Update the User Details by calling Put Method
        public string Put(User_Master user)
        {
            var _user = db.User_Master.Find(user.UserID);

            if (_user.UserID == null)
            {
                return "No User exist with the Id to update";
            }

            else
            {
                _user.UserID = user.UserID;
                _user.UserName = user.UserName;
                _user.UserPassword = user.UserPassword;
                _user.UserType = user.UserType;

                db.Entry(_user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return ("User Details updated successfully");
            }
        }

        //Delete the User by User_Id
        public string Delete(string id)
        {
            User_Master user = db.User_Master.Find(id);

            if (user == null)
            {
                return "No User exist with the Id to delete";
            }

            else
            {
                db.User_Master.Remove(user);
                db.SaveChanges();
                return "User Deleted";
            }
        }
    }
}
