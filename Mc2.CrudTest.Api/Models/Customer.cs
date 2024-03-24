using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Api.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
               
        public string DateOfBirth { get; set; }
               
        public string PhoneNumber { get; set; }
               
        public string Email { get; set; }
               
        public string BankAccountNumber { get; set; }
    }
}

