using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;

namespace TravelRepublic.Service
{
    public interface IFlightBuilderService
    {
        IList<Flight> GetFlights();
    }
}
