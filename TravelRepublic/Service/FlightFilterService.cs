using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;
using TravelRepublic.Repository;

namespace TravelRepublic.Service
{
    public class FlightFilterService : IFlightFilterService
    {
        private readonly IFilterRepository _repository;

        public FlightFilterService(IFilterRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Return the flights depart before the current date/time.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlightDepartBefore(IEnumerable<Flight> flights)
        {
            return _repository.FlightFilter(flights);
        }

        /// <summary>
        /// Return the flights having a segment with an arrival date before the departure date.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlightSegmetArrivedBefore(IEnumerable<Flight> flights)
        {
            return _repository.FlightFilter(flights);
        }

        /// <summary>
        /// Return the flights spend more than 2 hours on the ground.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        public IEnumerable<Flight> GetFlightSpendMoreTimeOnGround(IEnumerable<Flight> flights)
        {
            return _repository.FlightFilter(flights);
        }
    }
}
