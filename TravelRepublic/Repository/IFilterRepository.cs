using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Repository
{
    public interface IFilterRepository
    {
        IEnumerable<Flight> FlightFilter(IEnumerable<Flight> flights);
    }
}
