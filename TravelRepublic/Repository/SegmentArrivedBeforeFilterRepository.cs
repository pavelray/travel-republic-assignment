using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Repository
{
    public class SegmentArrivedBeforeFilterRepository : IFilterRepository
    {
        /// <summary>
        /// Flight Filter - Return a segment with an arrival date before the departure date
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> FlightFilter(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("flights");
            }

            return flights.Where(f => f.Segments.Any(s => s.ArrivalDate < s.DepartureDate));
        }


    }
}
