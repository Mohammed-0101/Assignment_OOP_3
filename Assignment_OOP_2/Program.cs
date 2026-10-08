using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_OOP_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part 01 : Theoretical Questions
            #region Question 1
            // Question A
            /*
             Class:
            1- A reference type. 2- Can inherit from another class. 3- impliment in Big Projects.

            Struct:
            1- A value type. 2- Cannot inherit from another class or struct. 3- impliment in Small Projects because it have 14 Bytes to be good performance.
             */


            //Question B

            /*
             Because The Classes support Inheritance , polymorphism and have a big size because it reference type
             */
            #endregion

            #region Question 2
            // a) Which class is the parent class?
            // Shipment

            //b) Which class is the child class?
            // ExpressShipment

            //c) What members are inherited by ExpressShipment?
            // TrackingCode

            //d) Why is inheritance better than duplicating the same code in multiple classes?
            //Inheritance reduces code duplication, improves maintainability,
            //and makes large C# applications easier to develop and manage.
            #endregion

            // Part 02 : Smart Delivery Management System
            //2. Create Three Shipment Types

            #region 5. In Main

            // 1. Create DeliveryCenter
            DeliveryCenter center = new DeliveryCenter();

            // 2. Read center name
            Console.WriteLine("=== Smart Delivery Management System ===");

            center.CenterName = ReadText("Enter Center Name: ");

            Console.WriteLine();

            // 3. Create StandardShipment
            Console.WriteLine("--- Enter Standard Shipment Data ---");

            Shipment standard = ReadShipment("Standard");

            center.AddShipment(standard);

            Console.WriteLine("Standard shipment added successfully.\n");


            // 4. Create ExpressShipment
            Console.WriteLine("--- Enter Express Shipment Data ---");

            Shipment express = ReadShipment("Express");

            center.AddShipment(express);

            Console.WriteLine("Express shipment added successfully.\n");


            // 5. Create InternationalShipment
            Console.WriteLine("--- Enter International Shipment Data ---");

            Shipment international = ReadShipment("International");

            center.AddShipment(international);

            Console.WriteLine("International shipment added successfully.\n");


            // 6. Print all shipments
            center.PrintAllShipments();


            // 7. Search using tracking code indexer
            Console.WriteLine();

            string searchCode = ReadText(
                "Enter a tracking code to search: ");

            Shipment foundShipment = center[searchCode];

            if (foundShipment != null)
            {
                Console.WriteLine("\nShipment Found:");

                foundShipment.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }


            // 8. Remove a shipment
            Console.WriteLine();

            string removeCode = ReadText(
                "Enter a tracking code to remove: ");

            if (center.RemoveShipment(removeCode))
            {
                Console.WriteLine("Shipment removed successfully.");
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }


            // 9. Print remaining shipments
            Console.WriteLine("\n--- Remaining Shipments ---");

            center.PrintAllShipments();


            // 10. Demonstrate DeliveryAddress struct copy behavior
            Console.WriteLine("\n--- Struct Copy Test ---");

            DeliveryAddress originalAddress = standard.Destination;

            DeliveryAddress copiedAddress = originalAddress;

            copiedAddress.BuildingNumber = 20;
            copiedAddress.Street = "Makram Ebeid Street";

            Console.WriteLine(
                $"Original Address: {originalAddress.GetFullAddress()}");

            Console.WriteLine(
                $"Copied Address: {copiedAddress.GetFullAddress()}");
        }


        // Read shipment information and create the appropriate type
        static Shipment ReadShipment(string shipmentType)
        {
            string trackingCode = ReadText("Tracking Code: ");

            string description = ReadText("Description: ");

            decimal weight = ReadPositiveDecimal("Weight: ");

            decimal deliveryFee = ReadPositiveDecimal(
                "Delivery Fee: ");

            string city = ReadText("City: ");

            string street = ReadText("Street: ");

            int buildingNumber = ReadPositiveInteger(
                "Building Number: ");

            DeliveryAddress destination = new DeliveryAddress(
                city,
                street,
                buildingNumber);


            if (shipmentType == "Standard")
            {
                return new StandardShipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    destination);
            }


            if (shipmentType == "Express")
            {
                decimal extraFee = ReadNonNegativeDecimal(
                    "Extra Fee: ");

                return new ExpressShipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    destination,
                    extraFee);
            }


            if (shipmentType == "International")
            {
                string country = ReadText(
                    "Destination Country: ");

                decimal customsFee = ReadNonNegativeDecimal(
                    "Customs Fee: ");

                return new InternationalShipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    destination,
                    country,
                    customsFee);
            }

            throw new ArgumentException("Invalid shipment type.");
        }


        // Read a non-empty string
        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);

                string value = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }

                Console.WriteLine(
                    "Invalid input. Please enter a valid value.");
            }
        }


        // Read a decimal greater than 0
        static decimal ReadPositiveDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(
                        Console.ReadLine(),
                        out decimal value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine(
                    "Invalid input. Value must be greater than 0.");
            }
        }


        // Read a decimal greater than or equal to 0
        static decimal ReadNonNegativeDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(
                        Console.ReadLine(),
                        out decimal value) && value >= 0)
                {
                    return value;
                }

                Console.WriteLine(
                    "Invalid input. Value must be 0 or greater.");
            }
        }


        // Read a positive integer
        static int ReadPositiveInteger(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(
                        Console.ReadLine(),
                        out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine(
                    "Invalid input. Enter a positive integer.");
            }
            #endregion


        }
    }
}
