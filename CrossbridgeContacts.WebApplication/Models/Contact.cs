using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contacts.WebApplication.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        [Required]
        public int IdContact { get; set; }
        [MaxLength(150)]
        public string Company { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Middle { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Department { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
    }
}