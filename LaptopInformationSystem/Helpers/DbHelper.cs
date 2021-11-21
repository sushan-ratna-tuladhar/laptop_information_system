using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LaptopInformationSystem.Helpers
{
    class DbHelper
    {
        private string connectionString;
        private MySqlConnection conn;

        private void GetDbConnection()
        {
            try
            {
                this.connectionString = ConfigHelper.GetConfig("ConnectionString");
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                this.conn = conn;
            } catch (Exception ex)
            {
                Console.WriteLine("Error on GetDbConnection : " + ex.Message + ", stack: " + ex.StackTrace);
            }
        }

        public void UpdateAccessedDate()
        {
            try
            {
                this.GetDbConnection();
                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "UPDATE date_update SET accessed_on = now();";

                this.conn.Open();
                Console.WriteLine("Updating AccessDate");
                cmd.ExecuteReader();
                Console.WriteLine("AccessDate Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on UpdateAccessedDate : " + ex.Message + ", stack: " + ex.StackTrace);
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
            
        }

        public string AddDevice(string code, string model, string type, string purchasedOn)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "INSERT INTO devices(code, model, type, purchased_on) VALUES (@code, @model, @type, @purchasedOn);";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@purchasedOn", purchasedOn);
                Console.WriteLine("Adding Device, code: " + code + ", model: " + model + ", type: " + type + ", purchasedOn: " + purchasedOn.ToString());
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Device Added, code: " + code + ", model: " + model + ", type: " + type + ", purchasedOn: " + purchasedOn.ToString());
                return ("Device : " + code + " Added!!!");
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on AddDevice : " + ex.Message + ", stack: " + ex.StackTrace);
                return ("Something went wrong");
            }
            finally
            {
                if(this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }

        }

    }
}
