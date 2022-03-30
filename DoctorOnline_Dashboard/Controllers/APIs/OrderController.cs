using DoctorOnline_Dashboard.Areas;
using DoctorOnline_Dashboard.Areas.OrderManagement;
using DoctorOnline_Dashboard.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderManagement _orderManagement;
        public OrderController(IOrderManagement orderManagement)
        {
            _orderManagement = orderManagement;
        }

        [HttpPost]
        [Route("addOrder")]
        public IResponse AddNewOrder(OrderDto orderDto, [FromHeader(Name = "distance")] double distanceInKm)
        {
            return _orderManagement.AddNewOrder(orderDto, distanceInKm);
        }

        [HttpPost]
        [Route("patientConfirmOrder")]
        public IResponse PatientConfirmOrder(OrderDto orderDto)
        {
            return _orderManagement.PatientOrderConfirmation(orderDto);
        }

        [HttpPost]
        [Route("doctorConfirmOrder")]
        public IResponse DoctorConfirmOrder(OrderDto orderDto)
        {
            return _orderManagement.DoctorOrderConfirmation(orderDto);
        }
    }
}
