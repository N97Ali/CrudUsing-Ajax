using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required]
        public string Course { get; set; }
      
        public string Gender  { get; set; }
    }
}
