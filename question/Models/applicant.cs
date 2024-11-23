using Microsoft.AspNetCore.Identity;

namespace question.Models
{
    public class applicant : IdentityUser
    {
        public string addrss {  get; set; }
        public DateTime birthdate { get; set; }
    }
}
