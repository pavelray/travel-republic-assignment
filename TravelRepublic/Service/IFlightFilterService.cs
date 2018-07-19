using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Service
{
    public interface IFlightFilterService
    {
        /// <summary>
        /// Return the flights depart before the current date/time.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        IEnumerable<Flight> GetFlightDepartBefore(IEnumerable<Flight> flights);

        /// <summary>
        /// Return the flights having a segment with an arrival date before the departure date.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        IEnumerable<Flight> GetFlightSegmetArrivedBefore(IEnumerable<Flight> flights);

        /// <summary>
        /// Return the flights spend more than 2 hours on the ground.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        IEnumerable<Flight> GetFlightSpendMoreTimeOnGround(IEnumerable<Flight> flights);
    }
}
