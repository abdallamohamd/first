using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Azure.Core.HttpHeader;

namespace question.Models
{
    public class job
    {
        public int id { get; set; }
        public string  title {  get; set; }
        public string company {  get; set; }
        public string description {  get; set; }
        public string skills_required {  get; set; }
        public string location { get; set; }

    }
}
