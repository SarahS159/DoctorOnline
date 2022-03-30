using DoctorOnline_Dashboard.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.OrderManagement
{
    public interface IOrderManagement
    {
        public IResponse AddNewOrder(OrderDto orderDto, double distanceInKm);
        public int CalculateOrderCost(double distanceInKm, double specialityCost);
        public IResponse DoctorOrderConfirmation(OrderDto orderDto);
        public IResponse PatientOrderConfirmation(OrderDto orderDto);//orderStatus = 0 or 1 (0:ok, 1:cancel)

    }
}
