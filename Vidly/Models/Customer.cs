using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date of Birth")]
        [CheckMembershipAge]
        public DateTime DateOfBirth { get; set; }

        public bool IsSubscribledToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }
}