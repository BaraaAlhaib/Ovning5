using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GarageManager
    {
        private Garage<Vehicle> garage;

        public GarageManager()
        {
            garage = new Garage<Vehicle>(new Vehicle { RegistrationNumber = "", Color = "", NumberOfWheels = 0 }, 10);
        }

        public void ListAllVehicles()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                Console.WriteLine("___________");
                return;
            }

            Console.WriteLine("Parkerade fordon:");
            foreach (var vehicle in garage)
            {
                if (vehicle.RegistrationNumber != "")
                {
                    Console.WriteLine($"{vehicle.RegistrationNumber}, typ: {vehicle.VehicleType}, Färg:{vehicle.Color}, Antal hjul: {vehicle.NumberOfWheels} ");
                }
            }
            Console.WriteLine("___________");

        }

        public void ListOfTypes()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                Console.WriteLine("___________");
                return;
            }

            Console.WriteLine("Antal fordon per typ:");
            Enum.TryParse(Console.ReadLine(), out VehicleTypes vehicleType);

            var vehicleTypes = garage.Where(x => x.VehicleType == vehicleType);

            if (vehicleTypes.Any())
            {
                Console.WriteLine($"Antal fordonstyper: {vehicleTypes.Count()}");

                foreach (var vehicle in vehicleTypes)
                {
                    if (vehicle.RegistrationNumber != "")
                    {
                        Console.WriteLine($"{vehicle.RegistrationNumber}, typ: {vehicle.VehicleType}, Färg:{vehicle.Color}, Antal hjul: {vehicle.NumberOfWheels} ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Finns inte.");
            }
            Console.WriteLine("___________");
        }

        public void AddVehicle()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                return;
            }

            Console.WriteLine("Lägg till ett nytt fordon i garaget.");

            Console.Write("Ange registreringsnummer: ");
            string registrationNumber = Console.ReadLine();

            if (garage.Any(vehicle => vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Fordonet finns redan i garaget.");
                Console.WriteLine("___________");
                return;
            }

            Console.Write("Ange typ: ");
            Enum.TryParse(Console.ReadLine(), out VehicleTypes vehicleType);

            Console.Write("Ange färg: ");
            string color = Console.ReadLine();

            Console.Write("Antal hjul: ");
            string wheels = Console.ReadLine();
            int.TryParse(wheels, out int numberOfWheels);



            Vehicle newVehicle = new Vehicle { RegistrationNumber = registrationNumber, Color = color, NumberOfWheels = numberOfWheels, VehicleType = (VehicleTypes?)vehicleType };
            garage.ParkVehicle(newVehicle);
            Console.WriteLine("___________");
        }

        public void RemoveVehicle()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                return;
            }
            Console.Write("Ange registreringsnummer: ");
            string registrationNumber = Console.ReadLine();


            var vehicle = garage.Where(vehicle => vehicle.RegistrationNumber.Equals(registrationNumber)).FirstOrDefault();

            garage.RemoveVehicle(vehicle);

            Console.WriteLine("___________");
        }

        public void FindVehicleByRegistrationNumber()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                return;
            }

            Console.Write("Ange registreringsnummer: ");
            string registrationNumber = Console.ReadLine();


            var vehicle = garage.Where(vehicle => vehicle.RegistrationNumber.Equals(registrationNumber)).FirstOrDefault();

            if(vehicle != null)
            {
                Console.WriteLine($"{vehicle.RegistrationNumber}, typ: {vehicle.VehicleType}, Färg:{vehicle.Color}, Antal hjul: {vehicle.NumberOfWheels} ");
            }
            Console.WriteLine("___________");
        }

        public void SearchVehiclesByProperties()
        {
            if (garage == null)
            {
                Console.WriteLine("Garaget är inte skapat än.");
                return;
            }

            Console.Write("Färg: ");
            string color = Console.ReadLine();


            var vehicle = garage.Where(vehicle => vehicle.Color.Equals(color)).FirstOrDefault();

            if (vehicle != null)
            {
                Console.WriteLine($"{vehicle.RegistrationNumber}, typ: {vehicle.VehicleType}, Färg:{vehicle.Color}, Antal hjul: {vehicle.NumberOfWheels} ");
            }
            Console.WriteLine("___________");
        }
    }
}
