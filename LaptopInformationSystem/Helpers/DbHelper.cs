using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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

        //Devices
        public string AddDevices(DataTable newDevices)
        {
            try
            {
                string addDeviceCommand = "INSERT INTO devices(serial_number, type, purchased_on, purchased_from, sold_on, buyer_id, invoice_number, model_id) VALUES (@serial_number, @type, @purchased_on, @purchased_from, @sold_on, @buyer_id, @invoice_number, @model_id)";
                foreach (DataRow r in newDevices.Rows)
                {
                    int? soldToId;

                    soldToId = r["Sold to"] != null ? this.GetSoldToId(r["Sold to"].ToString()) : null;

                    string purchasedOn = r["Purchased on"] != null ? r["Purchased on"].ToString().Split(' ')[0] : null;
                    if (purchasedOn != null)
                    {
                        try
                        {
                            purchasedOn = DateTime.Parse(purchasedOn).ToString("yyyy-MM-dd");
                        }
                        catch
                        {
                            purchasedOn = null;
                        }
                    }
                    string soldOn = r["Sold on"] != null ? r["Sold on"].ToString().Split(' ')[0] : null;
                    if (soldOn != null)
                    {
                        try
                        {
                            soldOn = DateTime.Parse(soldOn).ToString("yyyy-MM-dd");
                        }
                        catch
                        {
                            soldOn = null;
                        }
                    }

                    this.GetDbConnection();

                    MySqlCommand cmd = this.conn.CreateCommand();
                    cmd.CommandText = addDeviceCommand;
                    cmd.Parameters.AddWithValue("@serial_number", r["S/N"]);
                    cmd.Parameters.AddWithValue("@type", r["Type"]);
                    cmd.Parameters.AddWithValue("@purchased_on", purchasedOn);
                    cmd.Parameters.AddWithValue("@purchased_from", r["Purchased from"]);
                    cmd.Parameters.AddWithValue("@buyer_id", soldToId);
                    cmd.Parameters.AddWithValue("@sold_on", soldOn);
                    cmd.Parameters.AddWithValue("@invoice_number", r["Invoice number"]);
                    cmd.Parameters.AddWithValue("@model_id", r["Model"]);

                    this.conn.Open();
                    cmd.ExecuteNonQuery();
                    this.conn.Close();
                }

                Console.WriteLine("Devices Added, total: " + newDevices.Rows.Count);
                return (newDevices.Rows.Count + " devices added!!!");
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

        public string UpdateSoldDevices(DataTable soldDevices, string soldTo, string soldOn)
        {
            try
            {
                int? soldToId = this.GetSoldToId(soldTo);

                string updateDeviceCommand = "UPDATE devices SET sold_on = @soldOn, buyer_id = @soldToId WHERE TRIM(LOWER(serial_number)) = TRIM(LOWER(@sn));";
                foreach (DataRow r in soldDevices.Rows)
                {
                    soldOn = soldOn != null ? soldOn.ToString().Split(' ')[0] : null;
                    if (soldOn != null)
                    {
                        try
                        {
                            soldOn = DateTime.Parse(soldOn).ToString("yyyy-MM-dd");
                        }
                        catch
                        {
                            soldOn = null;
                        }
                    }

                    this.GetDbConnection();

                    MySqlCommand cmd = this.conn.CreateCommand();
                    cmd.CommandText = updateDeviceCommand;
                    cmd.Parameters.AddWithValue("@soldOn", soldOn);
                    cmd.Parameters.AddWithValue("@soldToId", soldToId);
                    cmd.Parameters.AddWithValue("@sn", r["S/N"]);

                    this.conn.Open();
                    cmd.ExecuteNonQuery();
                    this.conn.Close();
                }
                Console.WriteLine("Devices Sold, total: " + soldDevices.Rows.Count);
                return (soldDevices.Rows.Count + " devices sold!!!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on UpdateSoldDevices : " + ex.Message + ", stack: " + ex.StackTrace);
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

        public DataTable GetDevices(string search, int modelId, int pageNumber, int pageSize, string orderBy, string orderDir)
        {
            DataTable results = new DataTable();
            int offset = (pageNumber - 1) * pageSize;
            string finalCommand = "";
            string searchCommand = "";
            string getDevicesCommand = 
                "SELECT d.id AS ID, b.id AS BrandId, b.name AS Brand, m.id AS ModelId, m.name AS Model, d.serial_number AS SN, d.type AS Type, d.purchased_from AS PurchasedFrom, purchased_on AS PurchasedOn, " +
                "d.invoice_number AS InvoiceNumber, buy.id AS BuyerId, buy.name AS SoldTo, d.sold_on AS SoldOn, d.update_remarks AS UpdateRemarks, d.repair_remarks AS RepairRemarks " + 
                "FROM devices d " + 
                "JOIN models m ON m.id = d.model_id " + 
                "JOIN brands b ON b.id = m.brand_id " +
                "LEFT JOIN buyers buy ON buy.id = d.buyer_id " +
                "WHERE 1=1 ";
            string pagingCommand = " LIMIT " + pageSize + " OFFSET " + offset;
            string orderByCommand = "";
            string modelCommand = "";

            try
            {
                this.GetDbConnection();

                if(search != "")
                {
                    search = "%" + search.ToUpper() + "%";
                    searchCommand = " AND (UPPER(d.serial_number) LIKE @search OR UPPER(m.name) LIKE @search OR UPPER(b.name) LIKE @search)";
                }

                if(modelId != 0)
                {
                    modelCommand = " AND d.model_id = @modelId";
                }

                if(orderBy != "")
                {
                    if(orderDir != "")
                    {
                        orderByCommand = " ORDER BY d.@orderBy @orderDir";
                    } else
                    {
                        orderByCommand = " ORDER BY d.@orderBy ASC";
                    }
                }
                else
                {
                    if (orderDir != "")
                    {
                        orderByCommand = " ORDER BY d.purchased_on @orderDir";
                    }
                    else
                    {
                        orderByCommand = " ORDER BY d.purchased_on DESC";
                    }
                }

                finalCommand = getDevicesCommand + modelCommand + searchCommand + orderByCommand + pagingCommand;

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = finalCommand;
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@orderBy", orderBy);
                cmd.Parameters.AddWithValue("@orderDir", orderDir);
                cmd.Parameters.AddWithValue("@modelId", modelId);

                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[16] {
                            new DataColumn("No."),
                            new DataColumn("ID"),
                            new DataColumn("BrandId"),
                            new DataColumn("Brand"),
                            new DataColumn("ModelId"),
                            new DataColumn("ModelName"),
                            new DataColumn("S/N"),
                            new DataColumn("Type"),
                            new DataColumn("Purchased from"),
                            new DataColumn("PurchasedOn"),
                            new DataColumn("Invoice number"),
                            new DataColumn("BuyerId"),
                            new DataColumn("Sold to"),
                            new DataColumn("SoldOn"),
                            new DataColumn("UpdateRemarks"),
                            new DataColumn("RepairRemarks")
                    });

                    //Set AutoIncrement True for the First Column.
                    results.Columns["No."].AutoIncrement = true;

                    //Set the Starting or Seed value.
                    results.Columns["No."].AutoIncrementSeed = offset + 1;

                    //Set the Increment value.
                    results.Columns["No."].AutoIncrementStep = 1;
                    while (dr.Read())
                    {
                        results.Rows.Add(null,
                            !Convert.IsDBNull(dr["ID"]) ? dr["ID"] : "",
                            !Convert.IsDBNull(dr["BrandId"]) ? dr["BrandId"] : "",
                            !Convert.IsDBNull(dr["Brand"]) ? dr["Brand"] : "",
                            !Convert.IsDBNull(dr["ModelId"]) ? dr["ModelId"] : "",
                            !Convert.IsDBNull(dr["Model"]) ? dr["Model"] : "",
                            !Convert.IsDBNull(dr["SN"]) ? dr["SN"] : "",
                            !Convert.IsDBNull(dr["Type"]) ? dr["Type"] : "",
                            !Convert.IsDBNull(dr["PurchasedFrom"]) ? dr["PurchasedFrom"] : "",
                            !Convert.IsDBNull(dr["PurchasedOn"]) ? Convert.ToDateTime(dr["PurchasedOn"]).ToString("dd/MM/yyyy") : "",
                            !Convert.IsDBNull(dr["InvoiceNumber"]) ? dr["InvoiceNumber"] : "",
                            !Convert.IsDBNull(dr["BuyerId"]) ? dr["BuyerId"] : "",
                            !Convert.IsDBNull(dr["SoldTo"]) ? dr["SoldTo"] : "",
                            !Convert.IsDBNull(dr["SoldOn"]) ? Convert.ToDateTime(dr["SoldOn"]).ToString("dd/MM/yyyy") : "",
                            !Convert.IsDBNull(dr["UpdateRemarks"]) ? dr["UpdateRemarks"] : "",
                            !Convert.IsDBNull(dr["RepairRemarks"]) ? dr["RepairRemarks"] : "");
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

        public DataTable GetDevicesForSoldOut(string serial)
        {
            DataTable results = new DataTable();
            string getDevicesCommand =
                "SELECT d.id AS ID, b.id AS BrandId, b.name AS Brand, m.id AS ModelId, m.name AS Model, d.serial_number AS SN, d.type AS Type, d.purchased_from AS PurchasedFrom, purchased_on AS PurchasedOn, " +
                "d.invoice_number AS InvoiceNumber, d.sold_to AS SoldTo, d.sold_on AS SoldOn, d.update_remarks AS UpdateRemarks, d.repair_remarks AS RepairRemarks " +
                "FROM devices d " +
                "JOIN models m ON m.id = d.model_id " +
                "JOIN brands b ON b.id = m.brand_id " +
                "WHERE model_id = (SELECT d2.model_id FROM devices d2 WHERE UPPER(d2.serial_number) LIKE @serial LIMIT 1) " +
                "ORDER BY d.purchased_on DESC";

            try
            {
                this.GetDbConnection();

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = getDevicesCommand;
                cmd.Parameters.AddWithValue("@serial", serial);

                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[15] {
                            new DataColumn("No."),
                            new DataColumn("ID"),
                            new DataColumn("BrandId"),
                            new DataColumn("Brand"),
                            new DataColumn("ModelId"),
                            new DataColumn("ModelName"),
                            new DataColumn("S/N"),
                            new DataColumn("Type"),
                            new DataColumn("Purchased from"),
                            new DataColumn("PurchasedOn"),
                            new DataColumn("Invoice number"),
                            new DataColumn("Sold to"),
                            new DataColumn("SoldOn"),
                            new DataColumn("UpdateRemarks"),
                            new DataColumn("RepairRemarks")
                    });

                    //Set AutoIncrement True for the First Column.
                    results.Columns["No."].AutoIncrement = true;

                    //Set the Starting or Seed value.
                    results.Columns["No."].AutoIncrementSeed = 1;

                    //Set the Increment value.
                    results.Columns["No."].AutoIncrementStep = 1;
                    while (dr.Read())
                    {
                        results.Rows.Add(null,
                            !Convert.IsDBNull(dr["ID"]) ? dr["ID"] : "",
                            !Convert.IsDBNull(dr["BrandId"]) ? dr["BrandId"] : "",
                            !Convert.IsDBNull(dr["Brand"]) ? dr["Brand"] : "",
                            !Convert.IsDBNull(dr["ModelId"]) ? dr["ModelId"] : "",
                            !Convert.IsDBNull(dr["Model"]) ? dr["Model"] : "",
                            !Convert.IsDBNull(dr["SN"]) ? dr["SN"] : "",
                            !Convert.IsDBNull(dr["Type"]) ? dr["Type"] : "",
                            !Convert.IsDBNull(dr["PurchasedFrom"]) ? dr["PurchasedFrom"] : "",
                            !Convert.IsDBNull(dr["PurchasedOn"]) ? Convert.ToDateTime(dr["PurchasedOn"]).ToString("dd/MM/yyyy") : "",
                            !Convert.IsDBNull(dr["InvoiceNumber"]) ? dr["InvoiceNumber"] : "",
                            !Convert.IsDBNull(dr["SoldTo"]) ? dr["SoldTo"] : "",
                            !Convert.IsDBNull(dr["SoldOn"]) ? Convert.ToDateTime(dr["SoldOn"]).ToString("dd/MM/yyyy") : "",
                            !Convert.IsDBNull(dr["UpdateRemarks"]) ? dr["UpdateRemarks"] : "",
                            !Convert.IsDBNull(dr["RepairRemarks"]) ? dr["RepairRemarks"] : "");
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetDevicesForSoldOut : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        public string UpdateDevice(int id, string serialNumber, int modelId, string type, string purchasedOn, string purchasedFrom, string soldOn, string soldTo, string invoiceNumber, string updateRemarks, string repairRemarks)
        {
            try
            {

                //get soldTo id first
                int? soldToId = this.GetSoldToId(soldTo);

                this.GetDbConnection();

                string addDeviceCommand = 
                    "UPDATE devices SET " +
                        "serial_number = @serialNumber, model_id = @modelId, type = @type, purchased_on = @purchasedOn, " +
                        "purchased_from = @purchasedFrom, sold_on = @soldOn, buyer_id = @soldToId, invoice_number = @invoiceNumber, " +
                        "repair_remarks = @repairRemarks, update_remarks = @updateRemarks " +
                        "WHERE id = @id";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@serialNumber", serialNumber);
                cmd.Parameters.AddWithValue("@modelId", modelId);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@purchasedOn", purchasedOn);
                cmd.Parameters.AddWithValue("@purchasedFrom", purchasedFrom);
                cmd.Parameters.AddWithValue("@soldOn", soldOn);
                cmd.Parameters.AddWithValue("@soldToId", soldToId);
                cmd.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                cmd.Parameters.AddWithValue("@updateRemarks", updateRemarks);
                cmd.Parameters.AddWithValue("@repairRemarks", repairRemarks);
                cmd.Parameters.AddWithValue("@id", id);

                Console.WriteLine("Updating Device with id : " + id);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Device with id updated : " + id);
                return ("Device : " + serialNumber + " Updated!!!");
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

        public int? GetSoldToId(string soldTo)
        {
            int? soldToId = null;

            try
            {
                this.GetDbConnection();
                MySqlCommand cmd = this.conn.CreateCommand();
                
                cmd.CommandText = "SELECT b.id FROM buyers b WHERE TRIM(LOWER(b.name)) = @soldTo LIMIT 1;";
                cmd.Parameters.AddWithValue("@soldTo", soldTo);

                this.conn.Open();
                soldToId = Convert.ToInt32(cmd.ExecuteScalar());
                this.conn.Close();

                //inserting new buyer
                if(soldToId == null || soldToId == 0)
                {
                    this.GetDbConnection();
                    MySqlCommand cmd2 = this.conn.CreateCommand();
                    cmd2.CommandText = "INSERT INTO buyers (name) VALUES (@soldTo); SELECT LAST_INSERT_ID();";
                    cmd2.Parameters.AddWithValue("@soldTo", soldTo);

                    this.conn.Open();
                    soldToId = Convert.ToInt32(cmd2.ExecuteScalar());
                    this.conn.Close();
                }

                return soldToId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetSoldToId : " + ex.Message + ", stack: " + ex.StackTrace);
                return soldToId;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        public string UpdateDeviceRemarks(int id, string updateRemarks, string repairRemarks)
        {
            try
            {
                this.GetDbConnection();

                string updateDeviceCommand =
                    "UPDATE devices SET " +
                        "repair_remarks = @repairRemarks, update_remarks = @updateRemarks " +
                        "WHERE id = @id";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = updateDeviceCommand;
                cmd.Parameters.AddWithValue("@updateRemarks", updateRemarks);
                cmd.Parameters.AddWithValue("@repairRemarks", repairRemarks);
                cmd.Parameters.AddWithValue("@id", id);

                Console.WriteLine("Updating Device with id : " + id);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Device with id updated : " + id);
                return ("Device Updated!!!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on UpdateDeviceRemarks : " + ex.Message + ", stack: " + ex.StackTrace);
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



        public string DeleteDevice(string serialNumber)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "DELETE FROM devices WHERE serial_number = @serialNumber";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@serialNumber", serialNumber);
                Console.WriteLine("Deleting Device with serial number : " + serialNumber);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Deleted device with serial number : " + serialNumber);
                return ("Device : " + serialNumber + " Deleted!!!");
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

        public string GetTotalDevices(string search, int modelId)
        {
            string total = "0";
            try
            {
                this.GetDbConnection();
                MySqlCommand cmd = this.conn.CreateCommand();
                string searchCommand = "";
                string modelCommand = "";

                if (search != "")
                {
                    search = "%" + search.ToUpper() + "%";
                    searchCommand = " AND (UPPER(d.serial_number) LIKE @search OR UPPER(m.name) LIKE @search OR UPPER(b.name) LIKE @search)";
                }
                if(modelId != 0)
                {
                    modelCommand = " AND d.model_id = @modelId";
                }

                cmd.CommandText = "SELECT COUNT(1) FROM devices d JOIN models m ON m.id = d.model_id JOIN brands b ON b.id = m.brand_id WHERE 1=1" + searchCommand + modelCommand;
                cmd.Parameters.AddWithValue("@search", search);
                cmd.Parameters.AddWithValue("@modelId", modelId);

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

        public string GetTotalDevicesForSoldOut(string serial)
        {
            string total = "0";
            try
            {
                this.GetDbConnection();
                MySqlCommand cmd = this.conn.CreateCommand();
                string serialCommand = " AND d.model_id = (SELECT d2.model_id FROM devices d2 WHERE UPPER(d2.serial_number) LIKE @serial LIMIT 1)";

                cmd.CommandText = "SELECT COUNT(1) FROM devices d JOIN models m ON m.id = d.model_id JOIN brands b ON b.id = m.brand_id WHERE 1=1" + serialCommand;
                cmd.Parameters.AddWithValue("@serial", serial);

                this.conn.Open();
                total = Convert.ToString(cmd.ExecuteScalar());
                this.conn.Close();
                return total;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetTotalDevicesForSoldOut : " + ex.Message + ", stack: " + ex.StackTrace);
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

        public DataTable GetReport()
        {
            DataTable results = new DataTable();
            string getReportCommand =
                "SELECT b.name AS Brand, m.name AS Model, COUNT(d.id) AS DeviceCount " +
                "FROM brands b " +
                "JOIN models m ON m.brand_id = b.id " +
                "LEFT JOIN devices d ON d.model_id = m.id " +
                "WHERE COALESCE(d.sold_on,'1990-01-01') <= '1990-01-01' OR COALESCE(d.invoice_number,'') = '' AND COALESCE(m.name,'') <> '' " +
                "GROUP BY b.name, m.name " +
                "ORDER BY b.name, m.name";

            try
            {
                this.GetDbConnection();

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = getReportCommand;
                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[4] {
                            new DataColumn("No."),
                            new DataColumn("Brand"),
                            new DataColumn("Model"),
                            new DataColumn("Device count")
                    });

                    //Set AutoIncrement True for the First Column.
                    results.Columns["No."].AutoIncrement = true;

                    //Set the Starting or Seed value.
                    results.Columns["No."].AutoIncrementSeed = 1;

                    //Set the Increment value.
                    results.Columns["No."].AutoIncrementStep = 1;
                    while (dr.Read())
                    {
                        results.Rows.Add(null,
                            !Convert.IsDBNull(dr["Brand"]) ? dr["Brand"] : "",
                            !Convert.IsDBNull(dr["Model"]) ? dr["Model"] : "",
                            !Convert.IsDBNull(dr["DeviceCount"]) ? dr["DeviceCount"] : "");                    
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetReport : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        //Brands
        public DataTable GetBrands()
        {
            DataTable results = new DataTable();
            string getBrandsCommand = "SELECT id AS ID, name AS Brand FROM brands ORDER BY name";

            try
            {
                this.GetDbConnection();

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = getBrandsCommand;
                
                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[2] {
                        new DataColumn("ID"),
                        new DataColumn("Brand")
                    });

                    while (dr.Read())
                    {
                        results.Rows.Add(dr["ID"], dr["Brand"]);
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetBrands : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        public string AddBrand(string name)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "INSERT INTO brands(name) VALUES (@name);";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@name", name);
                Console.WriteLine("Adding Brand, name: " + name);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Brand Added, name: " + name);
                return ("Brand : " + name + " Added!!!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on AddBrand : " + ex.Message + ", stack: " + ex.StackTrace);
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

        //Models
        public DataTable GetModels(int brandId)
        {
            DataTable results = new DataTable();
            string getBrandsCommand = "SELECT id AS ID, name AS Model FROM models";
            string brandFilter = "";

            if(brandId != 0)
            {
                brandFilter = " WHERE brand_id = @brandId ORDER BY name";
            }

            try
            {
                this.GetDbConnection();

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = getBrandsCommand + brandFilter;
                cmd.Parameters.AddWithValue("@brandId", brandId);

                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[2] {
                        new DataColumn("ID"),
                        new DataColumn("Model")
                    });

                    while (dr.Read())
                    {
                        results.Rows.Add(dr["ID"], dr["Model"]);
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetModels : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
            }
            finally
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
        }

        public string AddModel(string name, int brandId)
        {
            try
            {
                this.GetDbConnection();

                string addDeviceCommand = "INSERT INTO models(name, brand_id) VALUES (@name, @brandId);";

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = addDeviceCommand;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brandId", brandId);
                Console.WriteLine("Adding Model, name: " + name + ", brand_id: " + brandId);
                this.conn.Open();
                cmd.ExecuteReader();
                this.conn.Close();
                Console.WriteLine("Model Added, name: " + name + ", brand_id: " + brandId);
                return ("Model : " + name + " Added!!!");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Duplicate code!!!");
                }

                Console.WriteLine("Error on AddModel : " + ex.Message + ", stack: " + ex.StackTrace);
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

        //Buyers
        public DataTable GetBuyers()
        {
            DataTable results = new DataTable();
            string getBrandsCommand = "SELECT id AS ID, name AS Buyer FROM buyers ORDER BY name";

            try
            {
                this.GetDbConnection();

                MySqlCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = getBrandsCommand;

                this.conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    results.Columns.AddRange(new DataColumn[2] {
                        new DataColumn("ID"),
                        new DataColumn("Buyer")
                    });

                    while (dr.Read())
                    {
                        results.Rows.Add(dr["ID"], dr["Buyer"]);
                    }
                }

                this.conn.Close();

                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetBuyers : " + ex.Message + ", stack: " + ex.StackTrace);
                return results;
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
