using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    public class StandardShipment : Shipment
    {
        public StandardShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination)

        : base(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination)
        {
        }
    }
}
