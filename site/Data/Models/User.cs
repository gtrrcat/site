using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace site.Data.Models
{
    public class User
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class dva
    {
        public int Id { get; set; }
        public string imya { get; set; }
    }
    public class msg
    {
        public int Id { get; set; }
        public string message { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime date { get; set; }
        
        

        public int sender_id { get; set; } = 3;

    }
}
