using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.entity;
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
                return rowAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error--" + ex.Message);
                return false;
            }
        }


    }
}
