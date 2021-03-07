using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.Models.Request
{
    public class CustomerRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room Id cannot be empty")]
        public int? RoomId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string CName { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [StringLength(40, ErrorMessage = "Maximum 40 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date cannot be empty")]
        [DataType(DataType.Date)]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Total number of persons cannot be empty")]
        public int? TotalPersons { get; set; }

        [Required(ErrorMessage = "Booking days cannot be empty")]
        public int? BookingDays { get; set; }

        [Required(ErrorMessage = "Advance cannot be empty")]
        public Decimal? Advance { get; set; }

        public RoomResponseModel Room { get; set; }
    }
}
