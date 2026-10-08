using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    public class ExpressShipment : Shipment
    {
        // Private field
        private decimal _extraFee;

        // ExtraFee: Must be >= 0
        public decimal ExtraFee
        {
            get { return _extraFee; }

            set
            {
                if (value >= 0)
                {
                    _extraFee = value;
                }
            }
        }

        // Constructor with constructor chaining
        public ExpressShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            decimal extraFee)

            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            ExtraFee = extraFee;
        }

        // Override estimated cost
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee+ (Weight *5) + ExtraFee;
            }
        }

        // Override PrintShipment
        public override void PrintShipment()
        {
            Console.WriteLine("Shipment Type: Express");

            base.PrintShipment();
            Console.WriteLine(
                $"Estimated Cost: {EstimatedCost} EGP");
            Console.WriteLine($"Extra Fee: {ExtraFee} EGP");
        }
    }
}
