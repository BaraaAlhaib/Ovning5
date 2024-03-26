using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        public Garage(T defaultVehicle, int capacity)
        {
            vehicles = new T[capacity];
            for (int i = 0; i < vehicles.Length; i++)
            {
                vehicles[i] = defaultVehicle;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ParkVehicle(T vehicle)
        {
            if (vehicle == null)
            {
                Console.WriteLine("Invalid vehicle.");
                return;
            }

            var emptyPlaces = vehicles.Where(x => x.RegistrationNumber == "").ToList();

            if (emptyPlaces.Count == 0)
            {
                Console.WriteLine("Garaget är fullt. Kan inte parkera fordonet.");
            }
            else
            {
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i].RegistrationNumber == "")
                    {
                        vehicles[i] = vehicle;
                        Console.WriteLine($"Fordon med registreringsnummer {vehicle.RegistrationNumber} parkerades i garaget.");
                        break;
                    }
                }
            }
        }
        public void RemoveVehicle(T vehicle)
        {
            int indexToRemove = Array.IndexOf(vehicles, vehicle);
            if (indexToRemove != -1)
            {
                vehicle.RegistrationNumber = "";
                vehicle.Color = "";
                vehicle.NumberOfWheels = 0;
                vehicle.VehicleType = null;

                vehicles[indexToRemove] = vehicle;
                Console.WriteLine($"Fordon med registreringsnummer {vehicle.RegistrationNumber} har tagits bort från garaget.");
            }
            else
            {
                Console.WriteLine($"Fordon med registreringsnummer {vehicle.RegistrationNumber} finns inte i garaget.");
            }
        }
    }
}

