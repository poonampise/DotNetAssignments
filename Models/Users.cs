using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication2.Models
{
    public class Users
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        

        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> cityList { set; get; }
    }
}