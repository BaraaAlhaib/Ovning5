using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            GarageManager garageManager = new GarageManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Välkommen till Garage Applikationen");
                Console.WriteLine("1. Lista samtliga parkerade fordon");
                Console.WriteLine("2. Lista fordonstyper och antal");
                Console.WriteLine("3. Lägg till fordon");
                Console.WriteLine("4. Ta bort fordon");
                Console.WriteLine("5. Sök efter fordon med registreringsnummer");
                Console.WriteLine("6. Sök efter fordon med specifika egenskaper");
                Console.WriteLine("7. Avsluta programmet");
                Console.Write("Ange ditt val: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        garageManager.ListAllVehicles();
                        break;
                    case "2":
                        garageManager.ListOfTypes();
                        break;
                    case "3":
                        garageManager.AddVehicle();
                        break;
                    case "4":
                        garageManager.RemoveVehicle();
                        break;
                    case "5":
                        garageManager.FindVehicleByRegistrationNumber();
                        break;
                    case "6":
                        garageManager.SearchVehiclesByProperties();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.WriteLine("___________");
                        break;
                }
            }
        }
    }


}
