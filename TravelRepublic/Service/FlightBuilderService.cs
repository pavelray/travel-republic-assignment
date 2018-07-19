using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRepublic.Model;
using TravelRepublic.Repository;

namespace TravelRepublic.Service
{
    public class FlightBuilderService : IFlightBuilderService
    {
        private IFlightBuilderRepository _repository { get; set; }

        public FlightBuilderService(IFlightBuilderRepository repository)
        {
            _repository = repository;
        }

        public IList<Flight> GetFlights()
        {
            return _repository.GetFlights();
        }
    }
}
