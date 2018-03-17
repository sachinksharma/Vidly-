using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public bool IsSubscribledToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MemberShipTypeId { get; set; }
    }
}