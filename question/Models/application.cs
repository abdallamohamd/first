using System.ComponentModel.DataAnnotations.Schema;

namespace question.Models
{
    public class application
    {
      public int id {  get; set; }
      [ForeignKey("job")]
      public int job_id {  get; set; }
      [ForeignKey("applicant")]
      public string applicant_id { get; set; }
      public DateTime application_date {  get; set; }   
      public string status {  get; set; }
      public applicant applicant { get; set; }
      public job? job {  get; set; } 

    }
}
