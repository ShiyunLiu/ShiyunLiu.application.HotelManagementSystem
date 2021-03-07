using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.Models.Request
{
    public class RoomTypeRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room type description cannot be empty")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string RtDesc { get; set; }

        [Required(ErrorMessage = "Rent cannot be empty")]
        public decimal? Rent { get; set; }
        public List<RoomResponseModel> Rooms { get; set; }
    }
}
