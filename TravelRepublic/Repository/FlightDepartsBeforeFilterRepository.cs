using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Repository
{
    public class FlightDepartsBeforeFilterRepository : IFilterRepository
    {
        private readonly DateTime _departsBeforeDate;

        public FlightDepartsBeforeFilterRepository(DateTime departsBeforeDate)
        {
            _departsBeforeDate = departsBeforeDate;
        }

        /// <summary>
        /// Flight Filter - Return flights depart before the _departsBeforeDate date and time 
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> FlightFilter(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("flights");
            }

            //return flights.Where(f => f.Segments.Where(s => s.DepartureDate < _departsBeforeDate).Any());
            return flights.Where(GetFilghtDepartedBefor);
        }

        /// <summary>
        /// Get the filghts departed before _departsBeforeDate date and time
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        private bool GetFilghtDepartedBefor(Flight flight)
        {
            return flight.Segments.Where(s => s.DepartureDate < _departsBeforeDate).Any();
        }
    }
}
