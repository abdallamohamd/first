using System.ComponentModel.DataAnnotations;

namespace question.view_model
{
    public class loginvm
    {
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rember { get; set; }
    }
}
