using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.Models.Request
{
    public class RoomRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room Type Id cannot be empty")]
        public int? RoomTypeId { get; set; }

        [DefaultValue(false)]
        public bool? Status { get; set; }
        public RoomTypeResponseModel RoomType { get; set; }
        public ICollection<ServiceResponseModel> Services { get; set; }
        public ICollection<CustomerResponseModel> Customers { get; set; }
    }
}
