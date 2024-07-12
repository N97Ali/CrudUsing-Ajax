using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Address
    {
        [Key]
        public  int Id { get; set; }    
        public string Village { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("Id")]
        public Student Student { get; set; }    


    }
}
