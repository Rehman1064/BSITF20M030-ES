using System;
using System.Collections.Generic;
namespace MYRIDE
{
    //Admin Class
    public class Admin
    {
        public List<Driver> Drivers { get; private set; }

        public Admin()
        {
            Drivers = new List<Driver>();
        }
        public void AddDriver()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Vehicle Type (Car, Bike, Rickshaw): ");
            string vehicleType = Console.ReadLine();
            Console.Write("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Enter Vehicle License Plate: ");
            string licensePlate = Console.ReadLine();
            Location currentLocation = new Location();
            Vehicle vehicle = new Vehicle(vehicleType, vehicleModel, licensePlate);
            Driver newDriver = new Driver(name, age, gender, address, "Phone Number", currentLocation, vehicle);
            Drivers.Add(newDriver);
            Console.WriteLine("Driver added successfully.");
        }
        public void RemoveDriver(int driverId)
        {
            Driver driverToRemove = Drivers.Find(driver => driver.id == driverId);

            if (driverToRemove != null)
            {
                Drivers.Remove(driverToRemove);
                Console.WriteLine($"Driver with ID {driverId} removed.");
            }
            else
            {
                Console.WriteLine($"Driver with ID {driverId} not found.");
            }
        }

        public void UpdateDriver(int driverId)
        {
            Driver driverToUpdate = Drivers.Find(driver => driver.id == driverId);

            if (driverToUpdate != null)
            {
                Console.WriteLine($"Driver with ID {driverId} exists.");
                Console.WriteLine("Enter updated information (leave empty to keep existing values):");

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) driverToUpdate.Name = name;

                Console.Write("Enter Age: ");
                string ageStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageStr))
                {
                    int age;
                    if (int.TryParse(ageStr, out age))
                    {
                        driverToUpdate.Age = age;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age format. Age not updated.");
                    }
                }

                Console.WriteLine("Driver information updated successfully.");
            }
            else
            {
                Console.WriteLine($"Driver with ID {driverId} not found.");
            }
        }

        public List<Driver> SearchDriver(int driverId, string name, int age, string gender, string address, string vehicleType, string vehicleModel, string licensePlate)
        {
            List<Driver> searchResults = Drivers.FindAll(driver =>
                (driver.id == driverId || driverId == 0) &&
                (string.IsNullOrEmpty(name) || driver.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) &&
                (age == 0 || driver.Age == age) &&
                (string.IsNullOrEmpty(gender) || driver.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(address) || driver.Address.Equals(address, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(vehicleType) || driver.vehicle.Type.Equals(vehicleType, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(vehicleModel) || driver.vehicle.Model.Equals(vehicleModel, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(licensePlate) || driver.vehicle.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase))
            );

            return searchResults;
        }
        public void EnterAsAdmin()
        {
            Console.WriteLine("Enter as Admin:");

            while (true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Admin admin = new Admin();
                        admin.AddDriver();
                        break;
                    case "2":
                        Admin remove = new Admin();
                        remove.RemoveDriver(121);
                        break;
                    case "3":
                        Admin update =new Admin();
                        update.UpdateDriver(122);
                        break;
                    case "4":
                        Admin search = new Admin();
                        search.SearchDriver();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }


	//Driver Class
        public class Driver
        {
            public string Name { get; set; }
            public int id { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Address { get; set; }
            public string PhoneNo { get; set; }
            public Location CurrentLocation { get; set; }
            public Vehicle vehicle { get; set; }
            public List<int> Ratings { get; set; } = new List<int>();
            public bool Availability { get; set; }

            public Driver(string name, int age, string gender, string address, string phoneNo, Location currentLocation, Vehicle vehicle)
            {
                Name = name;
                Age = age;
                Gender = gender;
                Address = address;
                PhoneNo = phoneNo;
                CurrentLocation = currentLocation;
                this.vehicle = vehicle;
                Availability = true;
            }

            public void UpdateAvailability()
            {
                Console.Write("Change availability status to 'true' or 'false': ");
                string input = Console.ReadLine().ToLower();

                if (input == "true")
                {
                    Availability = true;
                    Console.WriteLine("Availability status updated to 'true'.");
                }
                else if (input == "false")
                {
                    Availability = false;
                    Console.WriteLine("Availability status updated to 'false'.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                }
            }

            public double GetRating()
            {
                if (Ratings.Count == 0)
                {
                    return 0.0;
                }

                double totalRating = 0;
                foreach (int rating in Ratings)
                {
                    totalRating += rating;
                }

                return totalRating / Ratings.Count;
            }

            public void UpdateLocation()
            {
                Console.Write("Enter new location (latitude longitude): ");
                string[] locationInput = Console.ReadLine().Split(' ');

                if (locationInput.Length == 2 && double.TryParse(locationInput[0], out double latitude) && double.TryParse(locationInput[1], out double longitude))
                {
                    CurrentLocation = new Location(latitude, longitude);
                    Console.WriteLine("Location updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter valid latitude and longitude.");
                }
            }
        public Driver EnterAsDriver(int driverId, string driverName)
        {
            
            Driver driverToEnter = Driver.Find(driver => driver.Id == driverId && driver.Name == driverName);

            if (driverToEnter != null)
            {
                Console.WriteLine($"Hello {driverName}!");

                
                while (true)
                {
                    Console.WriteLine("Driver Menu:");
                    Console.WriteLine("1. Change availability");
                    Console.WriteLine("2. Change Location");
                    Console.WriteLine("3. Exit as Driver");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":

                            UpdateAvailability();
                            break;
                        case "2":

                            UpdateLocation();
                            break;
                        case "3":
                            
                            return driverToEnter;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Driver not found or not registered.");
            }

            return null;
        }
    }
    
    	//Location Class
        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public Location(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            public Location()
            {
                // Default constructor
            }
        }
    


    	//Passenger Class
        public class Passenger
        {
            public string Name { get; set; }
            public string PhoneNo { get; set; }

            public Passenger(string name, string phoneNo)
            {
                Name = name;
                PhoneNo = phoneNo;
            }

            public void BookRide()
            {
                Console.WriteLine("Booking a new ride...");

            }

            public void GiveRating()
            {
                Console.Write("Give rating (1 to 5) for the current ride: ");
                int rating;
                if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
                {

                    Console.WriteLine($"Thank you for rating: {rating}");
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a rating between 1 and 5.");
                }
            }
        }
    


   	//RideInterface Class
        public class RideInterface
        {
            private readonly Ride ride;

            public RideInterface()
            {
                ride = new Ride();
            }

            static public void Main()
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Admin");
                Console.WriteLine("3. Enter as Driver");
           
                Console.Write("Press 1 to 3 to select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Ride r = new Ride();
                        r.BookARide();
                        break;
                    case "2":

                    Admin admin = new Admin();
                    admin.EnterAsAdmin();
                    break;
                    case "3":
                    Console.WriteLine("Enter as a Driver");                        
                    break;
                    
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }

        }

    	//Ride Class
        public class Ride
        {
            public Location StartLocation { get; private set; }
            public Location EndLocation { get; private set; }
            public int Price { get; private set; }
            public Driver AssignedDriver { get; private set; }
            public Passenger BookingPassenger { get; private set; }

            public Ride()
            {
                StartLocation = new Location();
                EndLocation = new Location();
            }

            public void BookARide()
            {
                Console.Clear();
                Console.WriteLine("Book a Ride");

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();



                Console.Write("Enter Phone no: ");
                string phoneNo = Console.ReadLine();

                Console.Write("Enter Start Location (latitude, longitude): ");
                string[] startLocationInput = Console.ReadLine().Split(',');
                double startLatitude = double.Parse(startLocationInput[0]);
                double startLongitude = double.Parse(startLocationInput[1]);
                StartLocation = new Location(startLatitude, startLongitude);

                Console.Write("Enter End Location (latitude, longitude): ");
                string[] endLocationInput = Console.ReadLine().Split(',');
                double endLatitude = double.Parse(endLocationInput[0]);
                double endLongitude = double.Parse(endLocationInput[1]);
                EndLocation = new Location(endLatitude, endLongitude);

                Console.Write("Enter Ride Type (Car, Bike, Rickshaw): ");
                string rideType = Console.ReadLine();

                this.CalculatePrice(rideType);

                Console.ResetColor();

                Console.WriteLine(" THANK YOU ");
                Console.WriteLine($"Price for this ride is: {this.Price}");
                Console.Write("Enter 'Y' if you want to book the ride, enter 'N' if you want to cancel operation: ");
                string confirmation = Console.ReadLine();

                if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Happy Travel...!");
                    Console.Write("Give rating out of 5: ");
                    int rating = int.Parse(Console.ReadLine());
                    if (rating >= 1 && rating <= 5)
                    {

                        Console.WriteLine("Thank you for your rating!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid rating. Please enter a rating between 1 and 5.");
                    }
                }
            }

            private void CalculatePrice(string vehicleType)
            {
                double distance = CalculateDistance(this.StartLocation, this.EndLocation);
                double fuelPrice = 350; // Hardcoded petrol price per liter
                double commission = 0;

                switch (vehicleType)
                {
                    case "Bike":
                        commission = 0.05; // 5% commission
                        break;
                    case "Rickshaw":
                        commission = 0.10; // 10% commission
                        break;
                    case "Car":
                        commission = 0.20; // 20% commission
                        break;
                    default:
                        Console.WriteLine("Invalid vehicle type.");
                        return;
                }

                double price = (distance * fuelPrice) / 50 + (distance * fuelPrice * commission);
                this.Price = (int)price;
            }

            private double CalculateDistance(Location location1, Location location2)
            {
                double x1 = location1.Latitude;
                double y1 = location1.Longitude;
                double x2 = location2.Latitude;
                double y2 = location2.Longitude;

                double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                return distance;
            }
           
        }

 
  	//Vehicle Class
        public class Vehicle
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string LicensePlate { get; set; }

            public Vehicle(string type, string model, string licensePlate)
            {
                Type = type;
                Model = model;
                LicensePlate = licensePlate;
            }
        }
    
}