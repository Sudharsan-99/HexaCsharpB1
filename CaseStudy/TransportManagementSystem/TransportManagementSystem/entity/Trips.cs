using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.entity
{
    public class Trips
    {
        private int _tripID;
        private int _vehicleID;
        private int _routeID;
        private DateTime _departureDate;
        private DateTime _arrivaldate;
        private string _status;
        private string _tripType;
        private int _maxPassengers;

        private string[] AllowedStatuses = { "Available", "In Service", "Out of Service" };
        private string[] AllowedTripStatus = { "Freight", "Passenger" };

        public int TripID
        {
            get { return _tripID; }
            set { _tripID = value; }
        }

        public int VehicleID
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }

        public int RouteID
        {
            get { return _routeID; }
            set { _routeID = value; }
        }

        public DateTime DepartureDate
        {
            get { return _departureDate; }
            set { _departureDate = value; }
        }

        public DateTime ArrivalDate
        {
            get { return _arrivaldate; }
            set { _arrivaldate = value; }
        }
        public string Status
        {
            get { return _status; }
            set 
            {
                if (!(AllowedStatuses.Contains(value)))
                {
                    throw new ArgumentException("Error--The Status Does not Match ! \n Allowed status are \n1.Available,\n2.In Service,\n3.Out of Service");
                }
                _status = value;
            }
        }
        public string TripType
        {
            get { return _tripType; }
            set 
            {
                if (!(AllowedTripStatus.Contains(value)))
                {
                    throw new ArgumentException("Error--The Status Does not Match ! \n Allowed status are \n1.Available,\n2.In Service,\n3.Out of Service");
                }
                _tripType = value; 
            }
        }

        public int MaxPassengers
        {
            get { return _maxPassengers; }
            set { _maxPassengers = value; }
        }

        public Trips(int tripID, int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate,
                    string status, string tripType, int maxPassengers)
        {
            if (tripID < 0)
                throw new ArgumentException("Trip ID must be non-negative.");
            if (vehicleID <= 0)
                throw new ArgumentException("Vehicle ID must be a positive number.");
            if (routeID <= 0)
                throw new ArgumentException("Route ID must be a positive number.");

            if (departureDate >= arrivalDate)
                throw new ArgumentException("Arrival date must be later than departure date.");

            if (!Array.Exists(AllowedStatuses, s => s.Equals(status, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Invalid status. Allowed values: {string.Join(", ", AllowedStatuses)}");

            if (!Array.Exists(AllowedTripStatus, t => t.Equals(tripType, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Invalid trip type. Allowed values: {string.Join(", ", AllowedTripStatus)}");

            if (maxPassengers < 0)
                throw new ArgumentException("MaxPassengers cannot be negative.");

            TripID = tripID;
            VehicleID = vehicleID;
            RouteID = routeID;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Status = status;
            TripType = tripType;
            MaxPassengers = maxPassengers;
        }
    }
}
