﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Emp_MVC_UserLogin.Models
{
    public class MVC_UserMaster_Model
    {
         [Display(Name = "User ID")]
            [Required(ErrorMessage = "This field is required")]
            public string UserID { get; set; }


            [Display(Name = "User Name")]
            [Required(ErrorMessage = "This field is required")]
            public string UserName { get; set; }


            [Display(Name = "User Password")]
            [Required(ErrorMessage = "This field is required")]
            [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length Cannot be less than 8 characters")]
            public string UserPassword { get; set; }


            [Display(Name = "User Type")]
            [Required(ErrorMessage = "This field is required")]
            public string UserType { get; set; }

        }
}