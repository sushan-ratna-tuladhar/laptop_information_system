//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace LaptopInformationSystem.Helpers
//{
//    class BackgroundTasks
//    {
//        // Boolean that indicates wheter the process is running or has been stopped
//        private bool BackgroundTaskStopped;

//        // Expose the SynchronizationContext on the entire class
//        private readonly SynchronizationContext SyncContext;

//        // Create the 2 Callbacks containers
//        public event EventHandler<BackgroundTaskResponse> brandsCallback;
//        public event EventHandler<BackgroundTaskResponse> modelsCallback;

//        private Helpers.DbHelper db = new Helpers.DbHelper();

//        // Constructor of your heavy task
//        public BackgroundTasks()
//        {
//            // Important to update the value of SyncContext in the constructor with
//            // the SynchronizationContext of the AsyncOperationManager
//            SyncContext = AsyncOperationManager.SynchronizationContext;
//        }

//        // Method to start the thread
//        public void Start()
//        {
//            Thread thread = new Thread(LoadBrands);
//            thread.IsBackground = true;
//            thread.Start();
//        }

//        // Method to stop the thread
//        public void Stop()
//        {
//            BackgroundTaskStopped = true;
//        }

//        private DataTable LoadBrands()
//        {
//            DataTable brands = new DataTable();
//            brands = this.db.GetBrands();
//            return brands;
//        }

//        private DataTable LoadModels()
//        {
//            DataTable models = new DataTable();
//            models = this.db.GetModels(0);
//            return models;
//        }

//        // Methods that executes the callbacks only if they were set during the instantiation of
//        // the HeavyTask class !
//        private void triggerbrandsCallback(BackgroundTaskResponse response)
//        {
//            // If the callback 1 was set use it and send the given data (HeavyTaskResponse)
//            brandsCallback?.Invoke(this, response);
//        }

//        private void triggermodelsCallback(BackgroundTaskResponse response)
//        {
//            // If the callback 2 was set use it and send the given data (HeavyTaskResponse)
//            modelsCallback?.Invoke(this, response);
//        }
//    }

//    public class BackgroundTaskResponse
//    {
//        private readonly string message;

//        public BackgroundTaskResponse(string msg)
//        {
//            this.message = msg;
//        }

//        public string Message { get { return message; } }
//    }
//}
