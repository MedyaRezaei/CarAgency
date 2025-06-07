using CarAgancyLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CarAgancyLogin.Controllers
{
    public class VehicleController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Vehicles 
                                 (VehicleType, PlateNumber, Model, Color, ManufactureYear, FuelType, InsuranceExpiryDate, DriverUsername) 
                                 VALUES (@VehicleType, @PlateNumber, @Model, @Color, @ManufactureYear, @FuelType, @InsuranceExpiryDate, @DriverUsername)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd.Parameters.AddWithValue("@PlateNumber", vehicle.PlateNumber);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@ManufactureYear", vehicle.ManufactureYear);
                cmd.Parameters.AddWithValue("@FuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("@InsuranceExpiryDate", vehicle.InsuranceExpiryDate);
                cmd.Parameters.AddWithValue("@DriverUsername", vehicle.DriverUsername);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Vehicle> GetVehiclesByDriver(string driverUsername)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicles WHERE DriverUsername = @DriverUsername";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DriverUsername", driverUsername);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        VehicleID = Convert.ToInt32(reader["VehicleID"]),
                        VehicleType = reader["VehicleType"].ToString(),
                        PlateNumber = reader["PlateNumber"].ToString(),
                        Model = reader["Model"].ToString(),
                        Color = reader["Color"].ToString(),
                        ManufactureYear = Convert.ToInt32(reader["ManufactureYear"]),
                        FuelType = reader["FuelType"].ToString(),
                        InsuranceExpiryDate = Convert.ToDateTime(reader["InsuranceExpiryDate"]),
                        DriverUsername = reader["DriverUsername"].ToString()
                    });
                }
            }
            return vehicles;
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicles";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        VehicleID = Convert.ToInt32(reader["VehicleID"]),
                        VehicleType = reader["VehicleType"].ToString(),
                        PlateNumber = reader["PlateNumber"].ToString(),
                        Model = reader["Model"].ToString(),
                        Color = reader["Color"].ToString(),
                        ManufactureYear = Convert.ToInt32(reader["ManufactureYear"]),
                        FuelType = reader["FuelType"].ToString(),
                        InsuranceExpiryDate = Convert.ToDateTime(reader["InsuranceExpiryDate"]),
                        DriverUsername = reader["DriverUsername"].ToString()
                    });
                }
            }
            return vehicles;
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Vehicles SET 
                                VehicleType = @VehicleType, 
                                PlateNumber = @PlateNumber, 
                                Model = @Model, 
                                Color = @Color, 
                                ManufactureYear = @ManufactureYear, 
                                FuelType = @FuelType, 
                                InsuranceExpiryDate = @InsuranceExpiryDate, 
                                DriverUsername = @DriverUsername 
                                WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd.Parameters.AddWithValue("@PlateNumber", vehicle.PlateNumber);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@ManufactureYear", vehicle.ManufactureYear);
                cmd.Parameters.AddWithValue("@FuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("@InsuranceExpiryDate", vehicle.InsuranceExpiryDate);
                cmd.Parameters.AddWithValue("@DriverUsername", vehicle.DriverUsername);
                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteVehicle(int vehicleId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool IsPlateNumberExists(string plateNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Vehicles WHERE PlateNumber = @PlateNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

    }
}
