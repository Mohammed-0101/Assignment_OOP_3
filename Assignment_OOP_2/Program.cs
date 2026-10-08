using Assignment_OOP_2;
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
            #region Q1 Overloading, Overriding, and Binding
            //a)  What is the difference between Method Overloading and Method Overriding?
            /* Method Overloading:
             *      1- Same method name with different parameters.
             *      2- Usually occurs within the same class.
             *      3- Does not require inheritance.	
             *      4- Uses different numbers, types, or orders of parameters.	
             *      5- Associated with compile-time polymorphism.
             */
            /* Method Overriding:
            *       1- Same method name and parameter signature in a derived class.
                    2- Occurs between a base class and a derived class.
                    3- Requires inheritance.
                    4- Uses virtual in the base class and override in the derived class.
                    5- Associated with runtime polymorphism.
            */
            //b)  What is the difference between Static Binding and Dynamic Binding?
            /* Static Binding:
             *      1- Method selection is determined at compile time.	
                    2- Commonly associated with method overloading.	
                    3- Uses compile-time type information.	
                    4- Generally has less runtime dispatch overhead.	
             */
            /* Dynamic Binding:
             *      1- Method selection is determined at runtime.
             *      2- Commonly associated with method overriding.
             *      3- Uses the actual object's runtime type for virtual dispatch.
             *      4- May involve additional runtime dispatch overhead.
             */
            #endregion

            #region Q2 Sealed Classes and Methods
            //a)  What is the purpose of the sealed keyword when applied to a class?
            /*The sealed keyword prevents a class from being inherited by another class.
             */
            //b)  What is the difference between a sealed class and a sealed method?
            /* Sealed Class:
             *      1- Prevents inheritance of the entire class.
             *      2- Declared using sealed class.
             *      3- No class can derive from it.
             *      4-Can contain ordinary methods.
             */
            /* Sealed Method:
             *      1- Prevents further overriding of a specific method.
             *      2- Declared using sealed override.
             *      3- A derived class can inherit the method but cannot override it again.
             *      4- Must override an inherited virtual method.
             * 
             */
            //c)  Can a sealed method be overridden? Why?
            /* No. A sealed method cannot be overridden again in a derived class.
             * he sealed keyword prevents further overriding, 
             * ensuring that the implementation remains unchanged through subsequent inheritance.
             */
            #endregion

            // Part 02 : Smart Delivery Management System


            #region 5. In Main
            #region 1. Create a Driver

            int driverId = ReadPositiveInteger("Driver ID: ");
            string driverName = ReadText("Driver Full Name: ");
            string driverPhone = ReadText("Driver Phone Number: ");
            Driver driver = new Driver(driverId, driverName, driverPhone);
            #endregion

            #region 2. Create DeliveryCenter
            DeliveryCenter center = new DeliveryCenter();
            center.CenterName = ReadText("Enter Center Name: ");
            #endregion

            #region 3. Assign the Driver to the DeliveryCenter
            center.Driver = driver;
            Console.WriteLine($"\nAssigned Driver: {center.Driver.FullName}\n");
            #endregion

            #region Create StandardShipment
            Console.WriteLine("--- Enter Standard Shipment Data ---");
            Shipment standard = ReadShipment("Standard");
            #endregion

            #region Create ExpressShipment
            Console.WriteLine("--- Enter Express Shipment Data ---");
            Shipment express = ReadShipment("Express");
            #endregion

            #region Create InternationalShipment
            Console.WriteLine("--- Enter International Shipment Data ---");
            Shipment international = ReadShipment("International");
            #endregion

            #region Add all shipments to the DeliveryCenter
            center.AddShipment(standard);
            Console.WriteLine("Standard shipment added successfully.\n");

            center.AddShipment(express);
            Console.WriteLine("Express shipment added successfully.\n");

            center.AddShipment(international);
            Console.WriteLine("International shipment added successfully.\n");
            #endregion

            #region Print all shipments
            Console.WriteLine("\n=== Dynamic Binding: DeliveryCenter ===");
            center.PrintAllShipments();
            #endregion

            #region Call DeliveryHelper.PrintShipmentDetails() for each shipment.
            Console.WriteLine("\n=== Printing Using DeliveryHelper ===");
            DeliveryHelper.PrintShipmentDetails(standard);
            Console.WriteLine();
            DeliveryHelper.PrintShipmentDetails(express);
            Console.WriteLine();
            DeliveryHelper.PrintShipmentDetails(international);
            #endregion

            #region Demonstrate both versions of UpdateWeight().
            Console.WriteLine("\n=== Method Overloading: UpdateWeight ===");
            Console.WriteLine($"Original Weight             : {standard.Weight} KG");

            // Version 1: replaces the weight (e.g. 3 -> 5).
            decimal newWeight = standard.Weight + 2m;
            standard.UpdateWeight(newWeight);
            Console.WriteLine($"Updated Weight              : {standard.Weight} KG");

            // Version 2: 5 + 0.5 KG of packing -> 5.5 KG.
            standard.UpdateWeight(standard.Weight, 0.5m);
            Console.WriteLine($"Updated Weight After Packing: {standard.Weight} KG");
            Console.WriteLine($"New Estimated Cost          : {standard.EstimatedCost} EGP");
            #endregion

            #region Build a Shipment[] holding mixed types and print all of them in a loop.
            Console.WriteLine("\n=== Dynamic Binding: Shipment[] ===");
            Shipment[] mixedShipments = { standard, express, international };

            foreach (Shipment shipment in mixedShipments)
            {
                Console.WriteLine("------------------------------------------");
                shipment.PrintShipment(); // Correct override resolved at runtime.
            }
            #endregion

            #region Demonstrate the sealed class and sealed method (comments or code).

            Console.WriteLine("\n=== Sealed Class Example ===");
            CompletedShipment completed = new CompletedShipment(
                "DONE001", "Delivered Package", 1m, 50m,
                new DeliveryAddress("Cairo", "Main Street", 10));
            completed.PrintShipment();

            // This is illegal because CompletedShipment is sealed:
            // class ChildCompleted : CompletedShipment { }

            Console.WriteLine("\n=== Sealed Method Example ===");
            PriorityInternationalShipment priority = new PriorityInternationalShipment(
                "PRI001", "Urgent Documents", 2m, 80m,
                new DeliveryAddress("Cairo", "Main Street", 12),
                "Germany", 35m);
            priority.GenerateCustomsReport();
            #endregion



            #region Search using tracking code indexer
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
            #endregion

            #region Remove a shipment
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
            #endregion

            #region Print remaining shipments
            Console.WriteLine("\n--- Remaining Shipments ---");

            center.PrintAllShipments();
            #endregion

            //  Demonstrate DeliveryAddress struct copy behavior
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
