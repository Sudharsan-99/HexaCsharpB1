using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.entity;
using TransportManagementSystem.exception;
using TransportManagementSystem.util;

namespace TransportManagementSystem.dao
{
    public class TransportManagementServiceImpl : ITransportManagementService
    {
        public bool addVehicle(Vehicles vehicles)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "Insert into Vehicles(model,capacity,type,status)values(@model,@capacity,@type,@status)";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@model", vehicles.Model);
                cmd.Parameters.AddWithValue("@capacity", vehicles.Capacity);
                cmd.Parameters.AddWithValue("@type", vehicles.Type);
                cmd.Parameters.AddWithValue("@status", vehicles.Status);
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error adding vehicle: " + ex.Message);
                return false;
            }
        }

        public bool updateVehicle(Vehicles vehicle) 
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "Update vehicles set Model = @model ,Capacity = @capacity, Type = @type, Status = @status WHERE VehicleID = @vehicleID";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@type", vehicle.Type);
                cmd.Parameters.AddWithValue("@status", vehicle.Status);
                cmd.Parameters.AddWithValue("@vehicleID", vehicle.VehicleID);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected == 0) 
                {
                    throw new VechileNotFoundException("Error--Vehicle is not Found Please Enter a Valid VehicleID");
                }
                return true;
            }
            catch(VechileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error--" + ex.Message);
                return false;
            }
        }

        public bool deleteVehicle(int vehicleId)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "Delete from vehicles where vehicleId = @vehicleId";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@vehicleId", vehicleId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new VechileNotFoundException("Error--Vehicle is not Found Please Enter a Valid VehicleID");
                }
                return true;
            }
            catch(VechileNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while deleting vehicle: " + ex.Message);
                return false;
            }
        }

        public bool scheduleTrip(int vehicleId, int driverId, int routeId, string departureDate, string arrivalDate)
        {
            try
            {
                DateTime Arrivaldate = Convert.ToDateTime(arrivalDate);
                DateTime Departuredate = Convert.ToDateTime(departureDate);
                if (Arrivaldate > Departuredate)
                {
                    throw new ArgumentException("Departure date must be earlier than arrival date.");
                }
                DBConnection.connection = DBConnection.getConnection();
                string query = "insert into Trips(VehicleID,RouteID,Departuredate,Arrivaldate,DriverID) values(@vehicleId,@routeId,@Departuredate,@Arrivaldate, @driverId)";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@vehicleId", vehicleId);
                cmd.Parameters.AddWithValue("@routeId", routeId);
                cmd.Parameters.AddWithValue("@Departuredate", Departuredate);
                cmd.Parameters.AddWithValue("@Arrivaldate", Arrivaldate);
                cmd.Parameters.AddWithValue("@driverId", driverId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ArgumentException("Error--Can't SChedule a Trip,Please Enter the details Correctly");
                }
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error--"+ex.Message);
                return false;
            }
        }

        public bool cancelTrip(int tripId)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "update Trips set [Status] = 'Cancelled' WHERE TripID = @tripId";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@tripId", tripId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ArgumentException("Error--Please Enter The Correct TripId");
                }
                return true;
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); return false; }
            catch (Exception ex) { Console.WriteLine("UnexpectedError--" + ex.Message); return false; }

        }

        public bool bookTrip(int tripId, int passengerId, string bookingDate)
        {
            try
            {
                DateTime BookingDate = Convert.ToDateTime(bookingDate);
                DBConnection.connection = DBConnection.getConnection();
                string query = "insert into Bookings (TripID, PassengerID, BookingDate) " +
                              "values (@tripId, @passengerId, @bookingDate)";

                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@tripId", tripId);
                cmd.Parameters.AddWithValue("@passengerId", passengerId);
                cmd.Parameters.AddWithValue("@bookingDate", BookingDate);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new ArgumentException("Booking failed. Please check the input details.");
                }

                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid booking date format. Please use yyyy-MM-dd or a valid format.");
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                return false;
            }
        }

        public bool cancelBooking(int bookingId)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "update Bookings set [Status] = 'Cancelled' where BookingID = @bookingId";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@bookingId", bookingId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new BookingNotFoundException("Booking ID not found. Please provide a valid ID.");
                }

                return true;
            }
            catch (BookingNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
                return false;
            }
        }

        public bool allocateDriver(int tripId, int driverId)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();

                //Check if Trip Exist
                string checkTripQuery = "SELECT count(*) from Trips where TripID = @tripId";
                SqlCommand checkTripCmd = new SqlCommand(checkTripQuery, DBConnection.connection);
                checkTripCmd.Parameters.AddWithValue("@tripId", tripId);
                int tripExists = (int)checkTripCmd.ExecuteScalar();

                if (tripExists == 0)
                {
                    Console.WriteLine("Trip not found. Please enter a valid Trip ID.");
                    return false;
                }

                // Check if driver is available
                string checkDriverQuery = "select [Status] from Drivers where DriverID = @driverId";
                SqlCommand checkDriverCmd = new SqlCommand(checkDriverQuery, DBConnection.connection);
                checkDriverCmd.Parameters.AddWithValue("@driverId", driverId);
                object driverStatusObj = checkDriverCmd.ExecuteScalar();

                if (driverStatusObj == null)
                {
                    Console.WriteLine("Driver not found. Please enter a valid Driver ID.");
                    return false;
                }

                string driverStatus = driverStatusObj.ToString();
                if (driverStatus != "Available")
                {
                    Console.WriteLine("Driver is not available.");
                    return false;
                }

                // Update trip with driverId
                string updateTripQuery = "update Trips SET DriverID = @driverId Where TripID = @tripId";
                SqlCommand updateTripCmd = new SqlCommand(updateTripQuery, DBConnection.connection);
                updateTripCmd.Parameters.AddWithValue("@driverId", driverId);
                updateTripCmd.Parameters.AddWithValue("@tripId", tripId);
                int updatedTrip = updateTripCmd.ExecuteNonQuery();

                string updateDriverQuery = "Update Drivers SET [Status] = 'Assigned' Where DriverID = @driverId";
                SqlCommand updateDriverCmd = new SqlCommand(updateDriverQuery, DBConnection.connection);
                updateDriverCmd.Parameters.AddWithValue("@driverId", driverId);
                updateDriverCmd.ExecuteNonQuery();

                Console.WriteLine("Driver allocated successfully.");
                return updatedTrip > 0;
            }
            catch (Exception ex) { Console.WriteLine("Error--"+ex.Message);return false; }

        }

        public bool deallocateDriver(int tripId)
        {
            try
            {
                DBConnection.connection = DBConnection.getConnection();

                //  Get the assigned driver for the trip
                string getDriverQuery = "select DriverID from Trips where TripID = @tripId";
                SqlCommand getDriverCmd = new SqlCommand(getDriverQuery, DBConnection.connection);
                getDriverCmd.Parameters.AddWithValue("@tripId", tripId);
                object driverIdObj = getDriverCmd.ExecuteScalar();

                if (driverIdObj == null)
                {
                    Console.WriteLine("No driver is currently assigned to this trip.");
                    return false;
                }

                int driverId = Convert.ToInt32(driverIdObj);

                //  Deallocate driver from the trip
                string updateTripQuery = "update Trips SET DriverID = NULL where TripID = @tripId";
                SqlCommand updateTripCmd = new SqlCommand(updateTripQuery, DBConnection.connection);
                updateTripCmd.Parameters.AddWithValue("@tripId", tripId);
                int updatedTrip = updateTripCmd.ExecuteNonQuery();

                //  Set driver status back to Available
                string updateDriverQuery = "update Drivers set Status = 'Available' where DriverID = @driverId";
                SqlCommand updateDriverCmd = new SqlCommand(updateDriverQuery, DBConnection.connection);
                updateDriverCmd.Parameters.AddWithValue("@driverId", driverId);
                updateDriverCmd.ExecuteNonQuery();
                if (updatedTrip == 0)
                {
                    Console.WriteLine("Failed to deallocate driver from the trip.");
                    return false;
                }
                Console.WriteLine("Driver deallocated successfully.");
                return updatedTrip > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error -- " + ex.Message);
                return false;
            }
        }


        public List<Bookings> getBookingsByPassenger(int passengerId)
        {
            List<Bookings> bookings = new List<Bookings>();

            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "SELECT * FROM Bookings WHERE PassengerID = @passengerId";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@passengerId", passengerId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int bookingId = (int)reader["BookingID"];
                    int tripId = (int)reader["TripID"];
                    DateTime bookingDate = (DateTime)reader["BookingDate"];
                    string status = reader["Status"].ToString();

                    Bookings booking = new Bookings(bookingId, tripId, passengerId, bookingDate, status);
                    bookings.Add(booking);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching bookings: " + ex.Message);
            }
            return bookings; 
        }

        public List<Bookings> getBookingsByTrip(int tripId)
        {
            List<Bookings> bookings = new List<Bookings>();

            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "SELECT * FROM Bookings WHERE TripID = @TripID";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                cmd.Parameters.AddWithValue("@TripID", tripId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int bookingId = (int)reader["BookingID"];
                    int TripId = (int)reader["TripID"];
                    int passengerId = (int)reader["PassengerID"];
                    DateTime bookingDate = (DateTime)reader["BookingDate"];
                    string status = reader["Status"].ToString();

                    Bookings booking = new Bookings(bookingId, tripId, passengerId, bookingDate, status);
                    bookings.Add(booking);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching bookings: " + ex.Message);
            }

            return bookings;
        }

        public List<Drivers> getAvailableDrivers()
        {
            List<Drivers> availableDrivers = new List<Drivers>();
            try
            {
                DBConnection.connection = DBConnection.getConnection();
                string query = "select * from Drivers where Status = 'Available'";
                SqlCommand cmd = new SqlCommand(query, DBConnection.connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int driverId = (int)reader["DriverID"];
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string licenseNumber = reader["LicenseNumber"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    string email = reader["Email"]?.ToString();
                    string status = reader["Status"].ToString();

                    Drivers driver = new Drivers(driverId, firstName, lastName, licenseNumber, phoneNumber, email, status);
                    availableDrivers.Add(driver);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving available drivers: " + ex.Message);
            }
            return availableDrivers;
        }


    }
}
