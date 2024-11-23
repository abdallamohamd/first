using Microsoft.AspNetCore.Server.HttpSys;
using System.ComponentModel.DataAnnotations;

namespace question.view_model
{
    public class regester_vm
    {
        [Required]
        [MaxLength(100)]
       
        public string name {  get; set; }
        [EmailAddress]
        public string  Email { get; set; }
        public string address { get; set; }
        public string phone {  get; set; }
        public DateTime birhdate { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmpassword { get; set; }
    }
}
