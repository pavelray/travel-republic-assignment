using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Repository
{
    public class SpendMoreTimeOnGroundFilterRepository : IFilterRepository
    {
        private readonly TimeSpan _maxTimeOnGround;

        public SpendMoreTimeOnGroundFilterRepository(TimeSpan maxTimeOnGround)
        {
            _maxTimeOnGround = maxTimeOnGround;
        }

        /// <summary>
        ///Flight filter - Return the flights spend more than _maxTimeOnGround on ground 
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> FlightFilter(IEnumerable<Flight> flights)
        {
            if (flights == null)
            {
                throw new ArgumentNullException("flights");
            }

            return flights.Where(GetFlightsSpendMoreTimeOnGround);
        }

        /// <summary>
        /// Get the flight segment spends more hour on ground
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        private bool GetFlightsSpendMoreTimeOnGround(Flight flights)
        {
            Segment previousSegment = null;
            foreach (var segment in flights.Segments)
            {
                if (previousSegment != null)
                {
                    if ((segment.DepartureDate - previousSegment.ArrivalDate) > _maxTimeOnGround)
                    {
                        return true;
                    }
                }
                previousSegment = segment;
            }
            return false;
        }
    }
}
