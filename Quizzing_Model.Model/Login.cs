using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quizzing_Model.Model
{
    public  class Login
    {
        public int id { get; set; }
        [Required]
        [DisplayName("First Name :-")]
        [RegularExpression(@"(a-zA-Z)", ErrorMessage = "Enter Only Character")]
        public string F_name { get; set; }
        [Required]
        [DisplayName("Last Name :- ")]
        public string L_name { get; set; }
        [Required]
        [DisplayName("Username :- ")]
        public string username { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail:- ")]
        public string E_mail { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Password :- ")]
        public string password { get; set; }

    }
}
