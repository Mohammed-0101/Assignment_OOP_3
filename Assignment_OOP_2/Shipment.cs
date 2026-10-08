using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    public class Shipment
    {
        // Private fields
        private string _trackingCode;
        private string _description;
        private decimal _weight;
        private decimal _deliveryFee;

        // TrackingCode: Read-only from outside the class
        public string TrackingCode
        {
            get { return _trackingCode; }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _trackingCode = value;
                }
            }
        }

        // Description: Read/write with validation
        public string Description
        {
            get { return _description; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _description = value;
                }
            }
        }

        // Weight: Must be greater than 0
        public decimal Weight
        {
            get { return _weight; }

            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
            }
        }

        // DeliveryFee: Public getter, private setter
        public decimal DeliveryFee
        {
            get { return _deliveryFee; }

            private set
            {
                if (value > 0)
                {
                    _deliveryFee = value;
                }
            }
        }

        // Destination
        public DeliveryAddress Destination { get; set; }

        // Calculated property
        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }
        // Composition
        public DeliveryAddress DeliveryAddress { get; }
        // Constructor 1
        public Shipment(string trackingCode)
            : this(
                trackingCode,
                "Unknown",
                1,
                50,
                new DeliveryAddress("Unknown", "Unknown", 1))
        {
        }

        // Constructor 2
        public Shipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            // Initialize valid default values
            _trackingCode = "Unknown";
            _description = "Unknown";
            _weight = 1;
            _deliveryFee = 50;

            // Apply validation through properties
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;

            Destination = destination;
        }

        // Update delivery fee
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        // Update Weight

        public void UpdateWeight(int newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }

        // Print shipment information
        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine(
                $"Destination: {Destination.GetFullAddress()}");

            
        }
    }
}
