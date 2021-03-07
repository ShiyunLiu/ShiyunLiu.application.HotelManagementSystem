using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.Models.Request
{
    public class ServiceRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room Id cannot be empty")]
        public int? RoomId { get; set; }

        [Required(ErrorMessage = "Service description cannot be empty")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string SDesc { get; set; }

        [Required(ErrorMessage = "Amount cannot be empty")]
        public decimal? Amount { get; set; }

        [Required(ErrorMessage = "Service date cannot be empty")]
        [DataType(DataType.Date)]
        public DateTime? ServiceDate { get; set; }
        public RoomResponseModel Room { get; set; }
    }
}
