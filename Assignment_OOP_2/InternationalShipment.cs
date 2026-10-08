using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    public class InternationalShipment : Shipment
    {
        // Private fields
        private string _destinationCountry = "Unknown";
        private decimal _customsFee;

        // DestinationCountry: Cannot be null, empty, or whitespace
        public string DestinationCountry
        {
            get { return _destinationCountry; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _destinationCountry = value;
                }
            }
        }

        // CustomsFee: Must be >= 0
        public decimal CustomsFee
        {
            get { return _customsFee; }

            set
            {
                if (value >= 0)
                {
                    _customsFee = value;
                }
            }
        }

        // Constructor with constructor chaining
        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)

            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        // Override EstimatedCost
        public override decimal EstimatedCost
        {
            get
            {
                return base.EstimatedCost + CustomsFee;
            }
        }

        // Override PrintShipment
        public override void PrintShipment()
        {
            Console.WriteLine("Shipment Type: International");

            base.PrintShipment();

            Console.WriteLine(
                $"Destination Country: {DestinationCountry}");

            Console.WriteLine(
                $"Customs Fee: {CustomsFee} EGP");
        }
    }
}
