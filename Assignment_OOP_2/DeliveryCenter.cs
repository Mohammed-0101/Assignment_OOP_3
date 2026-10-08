using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    public class DeliveryCenter
    {
        // Private shipment array
        private Shipment[] _shipments;

        // Center name
        public string CenterName { get; set; }

        // Constructor
        public DeliveryCenter()
        {
            _shipments = new Shipment[20];
            CenterName = "Unknown";
        }

        // Integer indexer
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < _shipments.Length)
                {
                    return _shipments[index];
                }

                return default;
            }

            set
            {
                if (index >= 0 && index < _shipments.Length)
                {
                    _shipments[index] = value;
                }
            }
        }

        // String indexer
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < _shipments.Length; i++)
                {
                    if (_shipments[i] != null &&
                        _shipments[i].TrackingCode == trackingCode)
                    {
                        return _shipments[i];
                    }
                }

                return default;
            }
        }

        // Add shipment
        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                return false;
            }

            for (int i = 0; i < _shipments.Length; i++)
            {
                // Find the first available position
                if (_shipments[i] == null)
                {
                    _shipments[i] = shipment;

                    return true;
                }
            }

            // Delivery center is full
            return false;
        }

        // Remove shipment using tracking code
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < _shipments.Length; i++)
            {
                if (_shipments[i] != null &&
                    _shipments[i].TrackingCode == trackingCode)
                {
                    // Remove shipment
                    _shipments[i] = null;

                    return true;
                }
            }

            // Shipment not found
            return false;
        }

        // Print all stored shipments
        public void PrintAllShipments()
        {
            Console.WriteLine(
                $"\n--- All Shipments in {CenterName} ---");

            bool hasShipments = false;

            for (int i = 0; i < _shipments.Length; i++)
            {
                if (_shipments[i] != null)
                {
                    hasShipments = true;

                    Console.WriteLine(
                        $"\n--- Shipment {i + 1} ---");

                    _shipments[i].PrintShipment();
                }
            }

            if (!hasShipments)
            {
                Console.WriteLine("No shipments available.");
            }
        }
    }
}
