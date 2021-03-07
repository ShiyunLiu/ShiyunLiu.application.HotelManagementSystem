using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public int? RoomTypeId { get; set; }
        public bool? Status { get; set; }

        public RoomTypeResponseModel RoomType { get; set; }
        public ICollection<ServiceResponseModel> Services { get; set; }
        public ICollection<CustomerResponseModel> Customers { get; set; }

    }
}
