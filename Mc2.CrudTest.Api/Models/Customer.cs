using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Api.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "TEXT")]
        public string FirstName { get; set; }

        [Column(TypeName = "TEXT")]
        public string LastName { get; set; }

        [Column(TypeName = "TEXT")]
        public string DateOfBirth { get; set; }

        [Column(TypeName = "TEXT")] //variable-length
        public string PhoneNumber { get; set; }

        [Column(TypeName = "TEXT")]
        public string Email { get; set; }

        [Column(TypeName = "TEXT")]
        public string BankAccountNumber { get; set; }
    }
}

