using System;
using System.Collections.Generic;
using System.Linq;

class Station
{
    private string name;
    private string arrivalTime;
    private string departureTime;
    private int availableSeats;

    public Station(string name, string arrivalTime, string departureTime, int availableSeats)
    {
        this.name = name;
        this.arrivalTime = arrivalTime;
        this.departureTime = departureTime;
        this.availableSeats = availableSeats;
    }

    public string Name
    {
        get { return name; }
    }

    public string ArrivalTime
    {
        get { return arrivalTime; }
    }

    public string DepartureTime
    {
        get { return departureTime; }
    }

    public int AvailableSeats
    {
        get { return availableSeats; }
    }
}

class Route
{
    private List<Station> stations;
    private int totalSeats;
    private string daysOfWeek;
    private int flightNumber;

    public Route(int flightNumber, string daysOfWeek, int totalSeats)
    {
        this.flightNumber = flightNumber;
        this.daysOfWeek = daysOfWeek;
        this.totalSeats = totalSeats;
        this.stations = new List<Station>();
    }

    public void AddStation(Station station)
    {
        stations.Add(station);
    }

    public void RemoveStation(Station station)
    {
        stations.Remove(station);
    }

    public void PrintRoute()
    {
        Console.WriteLine("Flight Number: " + flightNumber);
        Console.WriteLine("Days of the week: " + daysOfWeek);
        Console.WriteLine("Total Seats: " + totalSeats);
        Console.WriteLine("Stations:");
        foreach (Station station in stations)
        {
            Console.WriteLine(" - " + station.Name);
        }
    }

    public int FlightNumber
    {
        get { return flightNumber; }
    }

    public string DaysOfWeek
    {
        get { return daysOfWeek; }
    }

    public int TotalSeats
    {
        get { return totalSeats; }
    }

    public List<Station> Stations
    {
        get { return stations; }
    }
}

class TicketSystem
{
    private List<Route> routes = new List<Route>();

    public void AddRoute(int flightNumber, string daysOfWeek, int totalSeats)
    {
        Route route = new Route(flightNumber, daysOfWeek, totalSeats);
        while (true)
        {
            Console.WriteLine("Додайте станцію до маршруту (або натисніть Enter, щоб завершити): ");
            Console.Write("Назва станції: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                break;
            }
            Console.Write("Час прибуття: ");
            string arrivalTime = Console.ReadLine();
            Console.Write("Час відправлення: ");
            string departureTime = Console.ReadLine();
            Console.Write("Кількість вільних місць: ");
            int availableSeats = int.Parse(Console.ReadLine());

            Station station = new Station(name, arrivalTime, departureTime, availableSeats);
            route.AddStation(station);
        }

        routes.Add(route);
        Console.WriteLine("Маршрут з номером рейсу " + flightNumber + " був доданий.");
    }

    public void RemoveRouteByFlightNumber(int flightNumber)
    {
        Route routeToRemove = routes.FirstOrDefault(r => r.FlightNumber == flightNumber);
        if (routeToRemove != null)
        {
            routes.Remove(routeToRemove);
            Console.WriteLine("Маршрут з номером рейсу " + flightNumber + " був видалений.");
        }
        else
        {
            Console.WriteLine("Маршрут з номером рейсу " + flightNumber + " не знайдено.");
        }
    }

    public void ListRoutes()
    {
        foreach (Route route in routes)
        {
            route.PrintRoute();
            Console.WriteLine();
        }
    }

    public void SortRoutesByTotalSeats()
    {
        routes.Sort((r1, r2) => r1.TotalSeats - r2.TotalSeats);
    }

    public static void Main(string[] args)
    {
        TicketSystem ticketSystem = new TicketSystem();

        while (true)
        {
            Console.WriteLine("1. Додати маршрут");
            Console.WriteLine("2. Видалити маршрут");
            Console.WriteLine("3. Переглянути список маршрутів");
            Console.WriteLine("4. Відсортувати маршрути за кількістю місць");
            Console.WriteLine("5. Вийти");
            Console.Write("Оберіть опцію: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть номер рейсу: ");
                    int flightNumber = int.Parse(Console.ReadLine());
                    Console.Write("Введіть дні тижня: ");
                    string daysOfWeek = Console.ReadLine();
                    Console.Write("Введіть загальну кількість місць: ");
                    int totalSeats = int.Parse(Console.ReadLine());
                    ticketSystem.AddRoute(flightNumber, daysOfWeek, totalSeats);
                    break;
                case 2:
                    Console.Write("Введіть номер рейсу для видалення: ");
                    int flightNumberToDelete = int.Parse(Console.ReadLine());
                    ticketSystem.RemoveRouteByFlightNumber(flightNumberToDelete);
                    break;
                case 3:
                    ticketSystem.ListRoutes();
                    break;
                case 4:
                    ticketSystem.SortRoutesByTotalSeats();
                    Console.WriteLine("Маршрути відсортовані за кількістю місць.");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
