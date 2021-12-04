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
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on AddDevice : " + ex.Message + ", stack: " + ex.StackTrace);
                return ("Something went wrong");
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }

        }

        public DataTable GetDevices(string search, int pageNumber, int pageSize, string orderBy, string orderDir)
        {
            DataTable results = new DataTable();
            int offset = (pageNumber - 1) * pageSize;
            string finalCommand = "";
            string codeSearchCommand = "";
            string getDevicesCommand = "SELECT id AS ID, code AS Code, model AS Model, type AS Type, purchased_on AS \"Purchased on\" FROM devices WHERE 1=1";
            string pagingCommand = " LIMIT " + pageSize + " OFFSET " + offset;
            string orderByCommand = "";

            try
            {
                this.GetDbConnection();

                if(search != "")
                {
                    search = "%" + search.ToUpper() + "%";
                    codeSearchCommand = " AND (UPPER(code) LIKE @search OR UPPER(model) LIKE @search)";
                }

                if(orderBy != "")
                {
                    if(orderDir != "")
                    {
                        orderByCommand = " ORDER BY @orderBy @orderDir";
                    } else
                    {
                        orderByCommand = " ORDER BY @orderBy ASC";
                    }
                }
                else
                {
                    if (orderDir != "")
                    {
                        orderByCommand = " ORDER BY purchased_on @orderDir";
                    }
                    else
                    {
                        orderByCommand = " ORDER BY purchased_on ASC";
                    }
                }

                finalCommand = getDevicesCommand + codeSearchCommand + orderByCommand + pagingCommand;

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = finalCommand;
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@orderBy", orderBy);
                cmd.Parameters.AddWithValue("@orderDir", orderDir);

                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[6] {
                            new DataColumn("SerialNo"),
                            new DataColumn("ID"),
                            new DataColumn("Code"),
                            new DataColumn("Model"),
                            new DataColumn("Type"),
                            new DataColumn("Purchased on")
                    });

                    //Set AutoIncrement True for the First Column.
                    results.Columns["SerialNo"].AutoIncrement = true;

                    //Set the Starting or Seed value.
                    results.Columns["SerialNo"].AutoIncrementSeed = offset + 1;

                    //Set the Increment value.
                    results.Columns["SerialNo"].AutoIncrementStep = 1;
                    while (dr.Read())
                    {
                        results.Rows.Add(null, dr["ID"], dr["Code"], dr["Model"], dr["Type"], Convert.ToDateTime(dr["Purchased on"]).ToString("dd/MM/yyyy"));
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevices : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
            }
            finally
            {
                if(this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        public string UpdateDevice(int id, string code, string model, string type, string purchasedOn)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "UPDATE devices SET code = @code, model = @model, type = @type, purchased_on = @purchasedOn WHERE id = @id";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@purchasedOn", purchasedOn);
                cmd.Parameters.AddWithValue("@id", id);
                Console.WriteLine("Updating Device with id : " + id + "- code: " + code + ", model: " + model + ", type: " + type + ", purchasedOn: " + purchasedOn.ToString());
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Device with id : " + id + " updated, code: " + code + ", model: " + model + ", type: " + type + ", purchasedOn: " + purchasedOn.ToString());
                return ("Device : " + code + " Updated!!!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on UpdateDevice : " + ex.Message + ", stack: " + ex.StackTrace);
                return ("Something went wrong");
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }

        }

        public string DeleteDevice(string code)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "DELETE FROM devices WHERE code = @code";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@code", code);
                Console.WriteLine("Deleting Device with code : " + code);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Deleted device with code : " + code);
                return ("Device : " + code + " Deleted!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on DeleteDevice : " + ex.Message + ", stack: " + ex.StackTrace);
                return ("Something went wrong");
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }

        }

        public string GetTotalDevices()
        {
            string total = "0";
            try
            {
                this.GetDbConnection();
                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(1) FROM devices";

                this.conn.Open();
                total = Convert.ToString(cmd.ExecuteScalar());
                this.conn.Close();
                return total;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on UpdateAccessedDate : " + ex.Message + ", stack: " + ex.StackTrace);
                return total;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

    }
}
