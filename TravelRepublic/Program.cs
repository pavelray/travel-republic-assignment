using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;
using TravelRepublic.Repository;
using TravelRepublic.Service;

namespace TravelRepublic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Travel Republic");
            Console.WriteLine("");
            Output output = new Output();
            output.GetOutput();
            Console.ReadKey();
        }
    }

    class Output
    {
        private FlightFilterService _flightFilterService { get; set; }
        private FlightBuilderService _flightBuilderService { get; set; }

        public void GetOutput()
        {
            _flightBuilderService = new FlightBuilderService(new FlightBuilderRepository());

            var allFlights = _flightBuilderService.GetFlights();

            _flightFilterService = new FlightFilterService(new FlightDepartsBeforeFilterRepository(DateTime.Now));
            var result = _flightFilterService.GetFlightDepartBefore(allFlights).ToList();
            DisplayOutput(result, "Flights Depart before the current date/time");

            _flightFilterService = new FlightFilterService(new SegmentArrivedBeforeFilterRepository());
            result = _flightFilterService.GetFlightSegmetArrivedBefore(allFlights).ToList();
            DisplayOutput(result, "Have a segment with an arrival date before the departure date.");
            
            _flightFilterService = new FlightFilterService(new SpendMoreTimeOnGroundFilterRepository(TimeSpan.FromHours(2)));
            result = _flightFilterService.GetFlightSpendMoreTimeOnGround(allFlights).ToList();
            DisplayOutput(result, "Spend more than 2 hours on the ground");
            
        }

        public void DisplayOutput(IEnumerable<Flight>flights, string filterName)
        {
            Console.WriteLine("");
            Console.WriteLine(filterName);
            Console.WriteLine("--------------------------------------------------");
            foreach (var flight in flights)
            {
                foreach (var segment in flight.Segments)
                {
                    Console.WriteLine($"=> Arrival: {segment.ArrivalDate.ToString()} ---- Departure:{segment.DepartureDate.ToString()}");
                }
            }
        }

    }
}
