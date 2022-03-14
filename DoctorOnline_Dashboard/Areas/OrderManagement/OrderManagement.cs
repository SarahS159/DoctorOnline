using AutoMapper;
using DoctorOnline_Dashboard.Areas.DoctorsManagement;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using DoctorOnline_Dashboard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.OrderManagement
{
    public class OrderManagement : IOrderManagement
    {
        private readonly DoctorOnlineContext _doctorOnlineContext;
        private readonly IResponse _response;
        private readonly IDoctorsManagement _doctorsManagement;
        private readonly IMapper _mapper;
        public OrderManagement(DoctorOnlineContext doctorOnlineContext, IResponse response, IDoctorsManagement doctorsManagement, IMapper mapper)
        {
            _doctorOnlineContext = doctorOnlineContext;
            _response = response;
            _doctorsManagement = doctorsManagement;
            _mapper = mapper;
        }
        //TODO:Handle Exceptiones.
        public IResponse AddNewOrder(OrderDto orderDto)//TODO: ask kais to send "distanceInKm" in request headers.
        {
            List<OrderDto> orderDtoAsList = new List<OrderDto>();
            var doctor = _doctorsManagement.GetDoctorToHandleRequest(orderDto.specialityId, orderDto.patientCity);
            DateTime sysDate = DateTime.Now;
            Order order = _mapper.Map<Order>(orderDto);
            order.requestedDate = sysDate;
            order.changeStatusDate = sysDate;

            if (doctor == null)
            {
                order.orderStatus = "-1";//cancel
               // order.doctorId = -1;//recheck
                _doctorOnlineContext.Orders.Add(order);
                _doctorOnlineContext.SaveChanges();

                _response.errorCode = (int)Errors.No_Availble_Doctors_To_Handle_The_Order;
                _response.errorDescription = (Errors.No_Availble_Doctors_To_Handle_The_Order).ToString();
            }
            else if (doctor.doctorId == -1)
            {
                order.orderStatus = "-1";//cancel
                //order.doctorId = -1;//recheck
                _doctorOnlineContext.Orders.Add(order);
                _response.errorCode = (int)Errors.GeneralError;
                _response.errorDescription = (Errors.GeneralError).ToString();
            }
            //Calculate the order Cost. and then insert in database
            else
            {
                var speciality = _doctorOnlineContext.Specialities.SingleOrDefault(s => s.specialityId == orderDto.specialityId);
                int orderCost = CalculateOrderCost(500.0, speciality.specialityCost);
                order.orderCost = orderCost;
                order.doctorId = doctor.doctorId;
                order.doctorName = doctor.doctorName;
                order.specialityTitle = speciality.specialityTitle;
                order.orderStatus = "2";//pending
                _doctorOnlineContext.Add(order);
                _doctorOnlineContext.SaveChanges();
                orderDto.orderCost = orderCost;
                orderDto.doctorId = doctor.doctorId;
                orderDto.orderId = order.orderId;
                orderDto.orderStatus = order.orderStatus;
                orderDtoAsList.Add(orderDto);

                //Send response to the end user contain the order cost.
                _response.errorCode = (int)Errors.Success;
                _response.errorDescription = (Errors.Success).ToString();
                _response.data = orderDtoAsList;

            }
            return _response;
        }


        public int CalculateOrderCost(double distanceInKm, double specialityCost)
        {
            double routeCost;
            var costFactors = _doctorOnlineContext.OrderCostFactors.SingleOrDefault();

            double trafficFactor = ((costFactors.actual_KMs_in_1LT - costFactors.uncertanityFactor) + costFactors.actual_KMs_in_1LT) / 2;
            double fuelAmountIn1Km = 1 / trafficFactor;
            double chargedCostOfOneKm = fuelAmountIn1Km * costFactors.fuel_Price_Of_1lt;

            if (costFactors.oneWayDirection)
                routeCost = distanceInKm * chargedCostOfOneKm;
            else
                routeCost = distanceInKm * chargedCostOfOneKm * 2;

            double totalCost = routeCost + specialityCost;
            int roundedCost = (((int)totalCost + 99) / 100) * 100;

            return roundedCost;


        }

        public IResponse PatientOrderConfirmation(OrderDto orderDto)
        {
            //TODO: order should be displyed on the dashboard.
            var order = _doctorOnlineContext.Orders.SingleOrDefault(o => o.orderId == orderDto.orderId);
            DateTime sysDate = DateTime.Now;
            if (orderDto.orderStatus == "0")
            {
                order.orderStatus = "3";//Pending and  confirmed by patient
            }
            else
            {
                order.orderStatus = "-1";//Cancel
            }

            order.changeStatusDate = sysDate;
            _doctorOnlineContext.SaveChanges();

            _response.errorCode = (int)Errors.Success;
            _response.errorDescription = (Errors.Success).ToString();

            return _response;
            //TODO: send push notification to the doctor Id that exsit in orderDto.
        }

        //this api called when doctor click ok on the push notification
        public IResponse DoctorOrderConfirmation(OrderDto orderDto)
        {
            var doctor = _doctorOnlineContext.Doctors.SingleOrDefault(d => d.doctorId == orderDto.doctorId);
            var order = _doctorOnlineContext.Orders.SingleOrDefault(o => o.orderId == orderDto.orderId);
            doctor.doctorStatus = "1"; //1=busy
            order.orderStatus = "1";//Active
            _doctorOnlineContext.SaveChanges();

            _response.errorCode = (int)Errors.Success;
            _response.errorDescription = (Errors.Success).ToString();

            return _response;
        }
    }
}
